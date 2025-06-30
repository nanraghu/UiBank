using System.Collections.Generic;
using System.Threading.Tasks;
using UiPath.CodedWorkflows;
using System.Threading;
using UiPath.Robot.Activities.Api;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Performance;
using UiPath.Testing.Activities.Performance;

namespace UiBankTestCaseAutomation
{
    public class Bootloader : CodedWorkflow
    {

        [Workflow]
        public async Task Execute(string pipeName, string workflowPath, Dictionary<string, object> wfArgs, CancellationToken ct)
        {
            _ = serviceContainer.Resolve<UiPath.UIAutomationNext.API.Contracts.IUiAutomationAppService>();
            var api = new BootloaderApi(pipeName, this);

            // Wait until the connection is estabilished
            await api.ConnectAsync(workflowPath, wfArgs, ct);
        }
    }
}
