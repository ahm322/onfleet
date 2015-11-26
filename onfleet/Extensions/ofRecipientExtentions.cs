using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onfleet
{
    public static class ofRecipientExtentions
    {
        public static ofRecipient FindOrCreate(this ofRecipientService recipientService, string phoneNumber, ofRecipientsCreateOptions createOptions, ofRequestOptions requestOptions = null)
        {
            ofRecipient recipient = new ofRecipient();
            try
            {
                recipient = recipientService.FindByPhone(phoneNumber, requestOptions);
            }
            catch (ofException ex)
            {
                if (ex.Error.ErrorCode == "ResourceNotFound")
                {
                    recipient = recipientService.Create(createOptions, requestOptions);
                    return recipient;
                }
                throw ex;
            }
            

            return recipient;
        }
    }
}
