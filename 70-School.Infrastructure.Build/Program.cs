
using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using System.Collections.Generic;

var githubPipeline = new GithubPipeline
{
    Name = "70-School Build Process",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "master" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "master" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.Windows2022,

            Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Check Out"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Setup .Net",

                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "7.0.100",
                        IncludePrerelease = true,
                    }
                },


                new RestoreTask
                {
                    Name = "Restore Packages"
                },

                new DotNetBuildTask
                {
                    Name = "Build Projects"
                },

                new TestTask
                {
                    Name = "Run Test"
                }
            }
        }
    }
};

var adotnetClient = new ADotNetClient();

adotnetClient.SerializeAndWriteToFile(
    adoPipeline: githubPipeline,
    path: "../../../../.github/workflows/build.yml");
