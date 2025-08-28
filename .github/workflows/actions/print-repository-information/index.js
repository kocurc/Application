const core = require('@actions/core');
const github = require('@actions/github');

try {
    const repositoryInformationType = core.getInput("repository-information-type") || "basic";
    const context = github.context;

    console.log(`Chosen repository-information-type: ${repositoryInformationType}\n`);

    if (repositoryInformationType === "basic") {
        console.log("Print basic repository info:\n");
        console.log(`Action: ${context.action}`);
    }
    else if (repositoryInformationType === "extended") {
        console.log("\nPrint extended repository info:\n");
        console.log(`Event's name: ${context.eventName}`);

    }
    else {
        console.log("Unsupported repository-information-type")
    }
} catch (error) {
    core.setFailed(error.message);
}
