using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace onfleet
{
    public static class ofTaskExtensions
    {
        public static ofTask CreateWithDestinationAndWorker(this ofTaskService taskService, ofTaskCreateOptions taskCreateOptions, string address, string workerID, ofRecipientsCreateOptions recipientCreateOptions = null, ofRequestOptions requestOptions = null)
        {

            ofDestinationCreateOptions destinationCreateOptions = new ofDestinationCreateOptions
            {
                Address = new ofAddress
                {
                    Unparsed = address
                }
            };
            
            ofDestinationService destinationService = string.IsNullOrEmpty(taskService.ApiKey) ? new ofDestinationService() : new ofDestinationService(taskService.ApiKey);

            ofDestination destination = destinationService.Create(destinationCreateOptions, requestOptions);

            taskCreateOptions.DestinationId = destination.Id;

            if (recipientCreateOptions != null)
            {
                ofRecipientService recipientService = string.IsNullOrEmpty(taskService.ApiKey) ? new ofRecipientService() : new ofRecipientService(taskService.ApiKey);
                var recipient = recipientService.Create(recipientCreateOptions, requestOptions);
                taskCreateOptions.Recipients = new List<string> { recipient.Id };
            }

            var task = taskService.Create(taskCreateOptions, requestOptions);

            ofWorkerService workerService = string.IsNullOrEmpty(taskService.ApiKey) ? new ofWorkerService() : new ofWorkerService(taskService.ApiKey);
            ofWorkerUpdateOptions workerUpdateOptions = new ofWorkerUpdateOptions{ 
                Tasks = new List<string>{ task.Id}
            };
            workerService.Update(workerID, workerUpdateOptions, requestOptions);

            return taskService.Get(task.Id, requestOptions);

        }


        public static ofTask CreatePickupAndDelivery(this ofTaskService taskService, ofTaskCreateOptions pickupTaskCreateOptions, ofTaskCreateOptions deliveryTaskCreateOptions, ofRequestOptions requestOptions = null)
        {
            pickupTaskCreateOptions.PickupTask = true;

            var pickupTask = taskService.Create(pickupTaskCreateOptions, requestOptions);
            deliveryTaskCreateOptions.Dependencies = new List<string> { pickupTask.Id };
            var deliveryTask = taskService.Create(deliveryTaskCreateOptions, requestOptions);

            return deliveryTask;

        }

        public static ofWorker AssignToWorker(this ofTaskService taskService, string taskId, string workerId, ofRequestOptions requestOptions = null)
        {
            var workerService = string.IsNullOrEmpty(taskService.ApiKey) ? new ofWorkerService() : new ofWorkerService(taskService.ApiKey);

            ofWorkerUpdateOptions updateoptions = new ofWorkerUpdateOptions { Tasks = new List<string> { taskId } };

            var worker = workerService.Update(workerId, updateoptions, requestOptions);

            return worker;
        }
    }
}
