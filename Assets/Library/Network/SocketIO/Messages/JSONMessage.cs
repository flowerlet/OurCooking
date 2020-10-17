using System;
using LitJson;

namespace SocketIO.Messages
{
    public class JSONMessage : Message
    {
        public void SetMessage(object value)
        {
            this.MessageText = JsonMapper.ToJson(value);
        }

        public virtual T Message<T>()
        {
            return JsonMapper.ToObject<T>(MessageText);
        }

        public JSONMessage()
        {
            this.MessageType = SocketIOMessageTypes.JSONMessage;
        }
		 public JSONMessage(object jsonObject):this()
        {
   
            this.MessageText = JsonMapper.ToJson(jsonObject);
        }
		
        public JSONMessage(object jsonObject, int? ackId  , string endpoint ):this()
        {
            this.AckId = ackId;
            this.Endpoint = endpoint;
            this.MessageText = JsonMapper.ToJson(jsonObject);
        }

        public static JSONMessage Deserialize(string rawMessage)
        {
			JSONMessage message = new JSONMessage();
            //  '4:' [message id ('+')] ':' [message endpoint] ':' [json]
            //   4:1::{"a":"b"}
			message.RawMessage = rawMessage;

            string[] args = rawMessage.Split(SPLITCHARS, 4); // limit the number of '
            if (args.Length == 4)
            {
                int id;
                if (int.TryParse(args[1], out id))
					message.AckId = id;
				message.Endpoint = args[2];
				message.MessageText = args[3];
            }
			return message;
        }
    }
}
