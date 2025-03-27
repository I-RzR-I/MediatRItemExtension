// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-03-23 22:16
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-03-25 22:01
// ***********************************************************************
//  <copyright file="VersionCheckHelper.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EnvDTE90;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers.LogHelper;
using MediatRItemExtension.Models;
using MediatRItemExtension.Services;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A version check helper.
    /// </summary>
    /// =================================================================================================
    internal static class VersionCheckHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the market place API.
        /// </summary>
        /// =================================================================================================
        private const string MarketPlaceApi = "https://marketplace.visualstudio.com/_apis/public/gallery/extensionquery";

        private const string ApiPostRequest = @"
{
    ""assetTypes"": [],
    ""filters"": [{
            ""criteria"": [{
                    ""filterType"": 8,
                    ""value"": ""Microsoft.VisualStudio.Ide""
                }, {
                    ""filterType"": 12,
                    ""value"": ""4096""
                }, {
                    ""filterType"": 7,
                    ""value"": ""#VSIXNAME#""
                }
            ],
            ""pageNumber"": 1,
            ""pageSize"": 1,
            ""sortBy"": 0,
            ""sortOrder"": 0
        }
    ],
    ""flags"": 1
}
";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the serialize settings.
        /// </summary>
        /// =================================================================================================
        private static readonly JsonSerializerOptions SerializeSettings = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Check available version asynchronous.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <param name="solution">The solution.</param>
        /// <param name="solSettingsStore">The sol settings store.</param>
        /// <returns>
        ///     The check available version.
        /// </returns>
        /// =================================================================================================
        internal static async Task<VersionCheckResultType> CheckAvailableVersionAsync(AsyncPackage package,
            Solution3 solution, SolutionSettingsStoreService solSettingsStore)
        {
            try
            {
                var lastCheck = solSettingsStore.GetLastVersionCheckDate(solution);
                if (lastCheck.IsNull() || DateTime.Now.Subtract(lastCheck!.Value).TotalMinutes > 60)
                {
                    await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

                    var vsixInfo = VsixInfoHelper.Instance.GetManifest();
                    var apiResult = await ExecuteApiRequestAsync($"{InitResources.Author}.{vsixInfo.DisplayName}");
                    if (apiResult.IsNull())
                    {
                        solSettingsStore.SetLastVersionCheckDate(solution, DateTime.Now);
                        solSettingsStore.SetLastVersionCheckResult(solution, VersionCheckResultType.ErrorCheck);
                    }
                    else
                    {
                        solSettingsStore.SetLastVersionCheckDate(solution, DateTime.Now);

                        var sameVersion = apiResult.Results.First().Extensions.First().Versions
                                              .OrderByDescending(x => x.LastUpdated).First().Version ==
                                          vsixInfo.Version;
                        solSettingsStore.SetLastVersionCheckResult(solution, sameVersion
                            ? VersionCheckResultType.UpToDate
                            : VersionCheckResultType.ExistNewVersion);
                    }
                }

                return solSettingsStore.GetLastVersionCheckResult(solution);
            }
            catch (Exception e)
            {
                LoggerFile.Log(e);

                return VersionCheckResultType.ErrorCheck;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Executes the 'api request asynchronous' operation.
        /// </summary>
        /// <param name="extensionName">Name of the extension.</param>
        /// <returns>
        ///     The execute API request.
        /// </returns>
        /// =================================================================================================
        private static async Task<VersionCheckResult> ExecuteApiRequestAsync(string extensionName)
        {
            try
            {
                var jsonRequest = ApiPostRequest.Replace("#VSIXNAME#", extensionName);
                var httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(1) };
                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(MarketPlaceApi),
                    Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
                };

                httpRequest.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                httpRequest.Headers.TryAddWithoutValidation("Accept", "application/json;api-version=3.0-preview.1");

                var result = await httpClient.SendAsync(httpRequest);
                var message = await result.Content.ReadAsStringAsync();
                var deserializationResult = JsonSerializer.Deserialize<VersionCheckResult>(message, SerializeSettings);

                return deserializationResult;
            }
            catch (Exception e)
            {
                LoggerFile.Log(e);

                return null;
            }
        }
    }
}