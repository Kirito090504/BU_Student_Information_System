$PY_EXE = "python.exe"
$PY_VER = (3, 11)
$VENV_NAME = "venv"

function Check-PythonVersion {
    <#
    .SYNOPSIS
    Check if the Python version is equal to or above the required version.
    .PARAMETER pythonVersion
    The Python version to check.
    .PARAMETER requiredVersion
    The required Python version.
    #>
    param (
        [int[]]$pythonVersion,
        [int[]]$requiredVersion
    )

    if ($pythonVersion[0] -lt $requiredVersion[0] -or $pythonVersion[1] -lt $requiredVersion[1]) {
        Write-Host "Python v$($requiredVersion -join '.')+ is required. Please install Python v$($requiredVersion -join '.')+ before running this script."
        exit 3
    }
}

# OS check
if ($env:OS -ne "Windows_NT")
{
    Write-Host "This script is only for Windows."
    exit 1
}

# Check if python is installed
if (-not (Get-Command $PY_EXE -ErrorAction SilentlyContinue))
{
    Write-Host "Python is not installed. Please install Python v$($PY_VER -join '.')+ before running this script."
    exit 2
}

# Check python version. Must be $PY_VER or above.
$pythonVersion = (python --version).Split(' ')[1].Split('.') | ForEach-Object { [int]$_ }
Check-PythonVersion -pythonVersion $pythonVersion -requiredVersion $PY_VER

# Get PIP version
$pipVersion = (pip --version).Split(' ')[1].Split('.') | ForEach-Object { [int]$_ }

Write-Host "Python version detected: v$($pythonVersion -join '.') (OK)"
Write-Host "PIP version detected:    v$($pipVersion -join '.') (OK)`n"

# Check if venv is already created. If `--recreate` is passed, delete and recreate the venv.
if (-not (Test-Path $VENV_NAME))
{
    Write-Host "Creating virtual environment..."
    & $PY_EXE -m venv $VENV_NAME
    if ($LASTEXITCODE -ne 0)
    {
        Write-Host "Failed to create virtual environment. Exiting..."
        exit 4
    }
    Write-Host "Virtual environment created."
}
else
{
    if ("--recreate" -in $args)
    {
        Write-Host "Recreating virtual environment..."
        Remove-Item -Recurse -Force $VENV_NAME
        & $PY_EXE -m venv $VENV_NAME
        if ($LASTEXITCODE -ne 0)
        {
            Write-Host "Failed to recreate virtual environment. Exiting..."
            exit 5
        }
        Write-Host "Virtual environment recreated."
    }
    else
    {
        Write-Host "Virtual environment already exists. Continuing..."
    }
}

# Activate the virtual environment
Write-Host "Activating virtual environment..."
$activateScript = "$VENV_NAME\Scripts\Activate.ps1"
if (-not (Test-Path $activateScript))
{
    Write-Host "Failed to activate virtual environment. Exiting..."
    exit 6
}
. $activateScript
Write-Host "Virtual environment activated.`n"
Write-Host "Virtual environment: ${PWD}\$VENV_NAME"
Write-Host "Python Path:         $((Get-Command python).Source)"
$pythonVersion = (python --version).Split(' ')[1].Split('.') | ForEach-Object { [int]$_ }
if ($LASTEXITCODE -ne 0)
{
    Write-Host "Failed to get Python version. Exiting..."
    exit 7
}
$pipVersion = (pip --version).Split(' ')[1].Split('.') | ForEach-Object { [int]$_ }
if ($LASTEXITCODE -ne 0)
{
    Write-Host "Failed to get PIP version. Exiting..."
    exit 8
}
Write-Host "Python version:      v$($pythonVersion -join '.')"
Write-Host "PIP version:         v$($pipVersion -join '.')`n"

Check-PythonVersion -pythonVersion $pythonVersion -requiredVersion $PY_VER

# Install required packages
Write-Host "Installing required packages..."
$requirementsFile = "requirements.txt"
if (-not (Test-Path $requirementsFile))
{
    Write-Host "Requirements file not found. Exiting..."
    exit 9
}
& pip install -r $requirementsFile
if ($LASTEXITCODE -ne 0)
{
    Write-Host "Failed to install required packages. Exiting..."
    exit 10
}
Write-Host "Required packages installed."

Write-Host "`nSetup completed successfully! You can now start working on your project."
exit 0