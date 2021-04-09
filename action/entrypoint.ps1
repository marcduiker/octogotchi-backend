Write-Host $PSVersion

Write-Host "Hello Octogotchi!"

# curl post/get here, load repo name from param
Write-Host "Repo slug from Powershell: $($env:GITHUB_REPOSITORY)"

# act on the result