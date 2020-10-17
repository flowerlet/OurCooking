using System;
using SocketIO.Messages;

namespace SocketIO
{
	public interface IEndPointClient
	{
		void On(string eventName, Action<IMessage> action);
		void Emit(string eventName, Object payload, Action<Object>  callBack);
        void Send(IMessage msg);
	}
}
