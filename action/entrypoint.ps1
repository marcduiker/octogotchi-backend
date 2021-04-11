Write-Host $PSVersion

Write-Host "Hello Octogotchi!"

# load repo name from param
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
    $ISODATE = (Get-Date -UFormat '+%Y%m%d')
    return "$ISODATE"
}

# create a new issue with the date as the key
$repoInfo = "un-used"
$issuesRepositoryName = $env:GITHUB_REPOSITORY
$title = "Octogotchi message for today"
$issuePrefix = Get-IssuePrefix
$body = "Issue body"
$PAT = $env:INPUT_GITHUB_TOKEN
$userName = "***"

Write-Host "Using PAT with length [$($PAT.Length)]"
$issueNumber = CreateNewIssueForRepo -repoInfo $repoInfo -issuesRepositoryName $issuesRepositoryName -title $title -body $body -PAT $PAT -userName $userName -issuePrefix $issuePrefix
Write-Host "Working with issueId [$issueNumber]"

#curl post/get here
$url = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Rotating_earth_%28large%29.gif"
$result = Invoke-WebRequest -Uri $url -ErrorAction Stop

# act on the result

# create a new comment with the image in it:
$message = "Interact with your Octogotchi throughout the day: `r`n ![image of the day]($url)"
AddCommentToIssue -repoName $issuesRepositoryName -message $message -number $issueNumber -userName $userName -PAT $PAT