Write-Host $PSVersion

Write-Host "Hello Octogotchi!"

# curl post/get here, load repo name from param
Write-Host "Repo slug from PowerShell: $($env:GITHUB_REPOSITORY)"

# include local library code
. $PSScriptRoot\github-calls.ps1


# create a new issue with the date as the key
$repoInfo = ""
$issuesRepositoryName = $env:GITHUB_REPOSITORY
$title = "IssueForToday"
$body = "Issue body"
$PAT = $env:github_token
$userName = "***"

Write-Host "Using PAT with length [$($PAT.Length)]"
CreateNewIssueForRepo -repoInfo $repoInfo -issuesRepositoryName $issuesRepositoryName -title $title -body $body -PAT $PAT -userName $userName

# act on the result