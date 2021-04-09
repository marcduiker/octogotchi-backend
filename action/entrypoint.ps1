Write-Host $PSVersion

Write-Host "Hello Octogotchi!"

# curl post/get here, load repo name from param
Write-Host "Repo slug from PowerShell: $($env:GITHUB_REPOSITORY)"

# include local library code
. $PSScriptRoot\github-calls.ps1

function LogEnvVars {
    # log env vars
    Write-Host "Logging env vars:"
    (gci env:*).GetEnumerator() | Sort-Object Name | Out-String | Write-Host
}

function Get-IssuePrefix {
    # return the issue prefix for today so we can test if it already exists
    return "IssueForToday"
}

# create a new issue with the date as the key
$repoInfo = ""
$issuesRepositoryName = $env:GITHUB_REPOSITORY
$title = Get-IssuePrefix
$body = "Issue body"
$PAT = $env:INPUT_GITHUB_TOKEN
$userName = "***"

Write-Host "Using PAT with length [$($PAT.Length)]"
CreateNewIssueForRepo -repoInfo $repoInfo -issuesRepositoryName $issuesRepositoryName -title $title -body $body -PAT $PAT -userName $userName

# act on the result