using System.Collections.Generic;
using UnityEngine;

namespace OurCooking.Scenes.Test
{
    public class TestSceneManager : MonoBehaviour
    {
        protected SocketIO.Client SocketEntity;

        private void Start()
        {
            SocketEntity = new SocketIO.Client("http://127.0.0.1:80/");
            SocketEntity.On("connect", (fn) => {
                Debug.Log("connect - SocketEntity");

                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("msg", "what's up?");
                SocketEntity.Emit("SEND", args);
            });
            SocketEntity.On("RECV", (data) => {
                Debug.Log(data.Json.ToJsonString());
            });
            SocketEntity.Error += (sender, e) => {
                Debug.Log("SocketEntity Error: " + e.Message.ToString());
            };
            SocketEntity.Connect();
        }

        protected void Send()
        {
            Debug.Log("Sending");

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("msg", "hello!");
            SocketEntity.Emit("SEND", args);
        }

        protected void Close()
        {
            Debug.Log("Closing");

            SocketEntity.Close();
        }
    }
}
