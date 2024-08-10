# This script will create the docker image for Corent.
# It is intended to be run from the project root.

function Set-EnvironmentVariables {
    Get-Content .env | % {
        $name, $value = $_.split('=')
        if($name -ne $null -and $value -ne $null) {
            Set-Item -Path env:\$name -Value $value
        }
    }
}

function Build-DockerImage {
    docker build -t "${env:PROJECT__NAME}:${env:PROJECT__VERSION}-latest" .
}

Set-EnvironmentVariables
Build-DockerImage