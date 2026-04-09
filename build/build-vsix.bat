@echo off
cls

PowerShell -NoProfile -ExecutionPolicy ByPass -Command ".\build-vsix.ps1"

echo
pause