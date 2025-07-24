internal class Build : NukeBuild
{
	private static void Main(string[] args)
	{

	}

    [GitRepository]
    public readonly GitRepository GitRepository;
    [GitVersion]
    public readonly GitVersion GitVersion;
    [Solution]
    public readonly Solution Solution;

	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
	public readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
	[Parameter("Entity Framework update database project path")]
	public readonly string EfProjectPath;

	private Target PrintRepositoryData => _ => _
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

	private Target PrintVersionData => _ => _
		.Executes(() =>
		{
			Log.Information("Semantic version = {SemanticVersion}", GitVersion.SemVer);
			Log.Information("Assembly version = {AssemblyVersion}", GitVersion.AssemblySemVer);
			Log.Information("Assembly semantic file version = {AssemblySemanticFileVersion}",
				GitVersion.AssemblySemFileVer);
			Log.Information("Informational version = {InformationalVersion}",
				GitVersion.InformationalVersion);
		});

	private static Target Clean => _ => _
		.Executes(() =>
		{
			RootDirectory.GlobDirectories("**/bin", "**/obj")
				.ForEach(directory => directory.DeleteDirectory());
		});

	private static Target RestoreTools => _ => _
		.Executes(() =>
		{
			DotNetToolRestore();
		});

	private static Target Restore => _ => _
		.Executes(() =>
		{
			DotNetRestore();
		});

	private Target Compile => _ => _
        .Executes(() =>
        {
	        DotNetBuild(_ => _
		        .SetProjectFile(Solution.ToString())
		        .SetConfiguration(Configuration.ToString())
		        .SetVersion(GitVersion.SemVer)
		        .SetAssemblyVersion(GitVersion.AssemblySemVer)
		        .SetFileVersion(GitVersion.AssemblySemFileVer)
		        .SetInformationalVersion(GitVersion.InformationalVersion)
		        .EnableNoRestore()
	        );
        });

	private Target Full => _ => _
		.DependsOn(Clean, RestoreTools, Restore, Compile);

	private Target UpdateDatabase => _ => _
		.Executes(() =>
		{
			DotNet($"tool run dotnet-ef database update --project {EfProjectPath}");
		});

	protected override void OnBuildInitialized()
	{
		base.OnBuildInitialized();

		Logging.Level = GitHubActions.Instance is not null ? LogLevel.Trace : LogLevel.Normal;
	}
}
