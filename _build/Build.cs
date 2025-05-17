using System.Diagnostics.CodeAnalysis;
using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[SuppressMessage("ReSharper", "AllUnderscoreLocalParameterName")]
class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;
	[Solution] readonly Solution Solution;

	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

	[Parameter(description: "Skip all tests")]
	readonly bool SkipTests = false;

	const int MinimumUnitTestsCoveragePercentageValue = 80;

	AbsolutePath TestsDirectory => RootDirectory / "ApplicationTests";

	protected override void OnBuildInitialized()
	{
		base.OnBuildInitialized();

		Logging.Level = GitHubActions.Instance is not null ? LogLevel.Trace : LogLevel.Normal;
	}

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            RootDirectory.GlobDirectories("**/bin", "**/obj").ForEach(directory => directory.DeleteDirectory());
        });

    Target PrintRepositoryData => _ => _
	    .Executes(() =>
	    {
            Log.Information("Commit value = {RepositoryCommit}", GitRepository.Commit);
            Log.Information("Branch value = {RepositoryBranch}", GitRepository.Branch);
            Log.Information("Endpoint value = {RepositoryEndpoint}", GitRepository.Endpoint);
            Log.Information("Head value = {RepositoryHead}", GitRepository.Head);
            Log.Information("HTTPS URL value = {RepositoryHttpsUrl}", GitRepository.HttpsUrl);
            Log.Information("Identifier value = {RepositoryIdentifier}", GitRepository.Identifier);
            Log.Information("Local directory value = {RepositoryLocalDirectory}", GitRepository.LocalDirectory);
            Log.Information("Protocol value = {RepositoryProtocol}", GitRepository.Protocol);
            Log.Information("RemoteBranch value = {RepositoryRemoteBranch}", GitRepository.RemoteBranch);
            Log.Information("SSH URL value = {RepositorySshUrl}", GitRepository.SshUrl);
            Log.Information("Remote name value = {RepositoryRemoteName}", GitRepository.RemoteName);
            Log.Information("Tags count value = {TagsCount}", GitRepository.Tags.Count);
	    });

	Target Restore => _ => _
	    .DependsOn(PrintRepositoryData)
        .Executes(() =>
        {
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
	        DotNetBuild(_ => _
		        .SetProjectFile(Solution)
		        .SetConfiguration(Configuration)
		        .SetVersion(GitVersion.SemVer)
		        .SetAssemblyVersion(GitVersion.AssemblySemVer)
		        .SetFileVersion(GitVersion.AssemblySemFileVer)
		        .SetInformationalVersion(GitVersion.InformationalVersion));
        });
}
