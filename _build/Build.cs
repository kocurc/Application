[SuppressMessage("ReSharper", "AllUnderscoreLocalParameterName")]
internal class Build : NukeBuild
{
    [GitRepository]
    private readonly GitRepository _gitRepository;

    [GitVersion]
    private readonly GitVersion _gitVersion;

    [Solution]
    private readonly Solution _solution;

	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
	private readonly Configuration _configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

	private Target Clean => _ => _
		.Executes(() =>
		{
			RootDirectory.GlobDirectories("**/bin", "**/obj")
				.ForEach(directory => directory.DeleteDirectory());
		});

	private Target RestoreDotNetTools => _ => _
		.Executes(() =>
		{
			DotNetToolRestore();
		});

	private Target PrintRepositoryData => _ => _
		.Executes(() =>
		{
			Log.Information("Commit value = {RepositoryCommit}", _gitRepository.Commit);
			Log.Information("Branch value = {RepositoryBranch}", _gitRepository.Branch);
			Log.Information("Endpoint value = {RepositoryEndpoint}", _gitRepository.Endpoint);
			Log.Information("Head value = {RepositoryHead}", _gitRepository.Head);
			Log.Information("HTTPS URL value = {RepositoryHttpsUrl}", _gitRepository.HttpsUrl);
			Log.Information("Identifier value = {RepositoryIdentifier}", _gitRepository.Identifier);
			Log.Information("Local directory value = {RepositoryLocalDirectory}", _gitRepository.LocalDirectory);
			Log.Information("Protocol value = {RepositoryProtocol}", _gitRepository.Protocol);
			Log.Information("RemoteBranch value = {RepositoryRemoteBranch}", _gitRepository.RemoteBranch);
			Log.Information("SSH URL value = {RepositorySshUrl}", _gitRepository.SshUrl);
			Log.Information("Remote name value = {RepositoryRemoteName}", _gitRepository.RemoteName);
			Log.Information("Tags count value = {TagsCount}", _gitRepository.Tags.Count);
		});

	private Target PrintVersionData => _ => _
		.Executes(() =>
		{
			Log.Information("Semantic version = {SemanticVersion}", _gitVersion.SemVer);
			Log.Information("Assembly version = {AssemblyVersion}", _gitVersion.AssemblySemVer);
			Log.Information("Assembly semantic file version = {AssemblySemanticFileVersion}",
				_gitVersion.AssemblySemFileVer);
			Log.Information("Informational version = {InformationalVersion}",
				_gitVersion.InformationalVersion);
		});

	private Target Compile => _ => _
        .Executes(() =>
        {
	        DotNetBuild(_ => _
		        .SetProjectFile(_solution)
		        .SetConfiguration(_configuration)
		        .SetVersion(_gitVersion.SemVer)
		        .SetAssemblyVersion(_gitVersion.AssemblySemVer)
		        .SetFileVersion(_gitVersion.AssemblySemFileVer)
		        .SetInformationalVersion(_gitVersion.InformationalVersion));
        });

	public static int Main()
	{
		return Execute<Build>(expressions => expressions.Compile); ;
	}

	protected override void OnBuildInitialized()
	{
		base.OnBuildInitialized();

		Logging.Level = GitHubActions.Instance is not null ? LogLevel.Trace : LogLevel.Normal;
	}
}
