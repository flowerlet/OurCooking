using System.Collections.Generic;
using UnityEngine;

namespace OurCooking.Scenes.Test
{
    public class TestSceneManager : MonoBehaviour
    {
        SocketIOClient.Client socket;

        private void Start()
        {
            socket = new SocketIOClient.Client("http://127.0.0.1:80/");
            socket.On("connect", (fn) => {
                Debug.Log("connect - socket");

                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("msg", "what's up?");
                socket.Emit("SEND", args);
            });
            socket.On("RECV", (data) => {
                Debug.Log(data.Json.ToJsonString());
            });
            socket.Error += (sender, e) => {
                Debug.Log("socket Error: " + e.Message.ToString());
            };
            socket.Connect();
        }


        protected void Send()
        {
            Debug.Log("Sending");

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("msg", "hello!");
            socket.Emit("SEND", args);
        }

        protected void Close()
        {
            Debug.Log("Closing");

            socket.Close();
        }
    }
}
