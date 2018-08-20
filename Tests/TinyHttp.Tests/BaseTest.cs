﻿namespace Tiny.Http.Tests
{
    public class BaseTest
    {
        private readonly object _toLock = new object();
        private TinyHttpClient _client;
        private TinyHttpClient _clientXML;

        protected TinyHttpClient GetClient()
        {
            lock (_toLock)
            {
                if (_client == null)
                {
                    _client = new TinyHttpClient(Program.Client, "http://localhost:4242/api/");
                }
            }

            return _client;
        }

        protected TinyHttpClient GetClientXML()
        {
            lock (_toLock)
            {
                if (_clientXML == null)
                {
                    _clientXML = new TinyHttpClient(Program.Client, "http://localhost:4242/api/", new TinyXmlSerializer(), new TinyXmlDeserializer());
                }
            }

            return _clientXML;
        }
    }
}