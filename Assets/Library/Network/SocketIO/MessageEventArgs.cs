﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketIO.Messages;

namespace SocketIO
{
	public class MessageEventArgs : EventArgs
	{
		public IMessage Message { get; private set; }

		public MessageEventArgs(IMessage msg)
			: base()
		{
			this.Message = msg;
		}
	}
}
