const core = require('@actions/core');
const github = require('@actions/github');

try {
    const repositoryInformationType = core.getInput("repository-information-type");
    const context = github.context;

    if (repositoryInformationType === "basic") {
        console.log("Print basic repository info:\n");
        console.log(`Action: ${context.action}`);
        console.log(`Actor: ${context.actor}`);
        console.log(`Event's name: ${context.eventName}`);
        console.log(`API's URL: ${context.apiUrl}`);
        console.log(`Reference: ${context.ref}`);
    }
    else if (repositoryInformationType === "extended") {
        console.log("\nPrint extended repository info:\n");
        console.log(`Event's installation ID: ${context.payload.installation.id}`);
    }
    else {
        console.log("Insupported repository-information-type")
    }
} catch (error) {
    core.setFailed(error.message);
}
