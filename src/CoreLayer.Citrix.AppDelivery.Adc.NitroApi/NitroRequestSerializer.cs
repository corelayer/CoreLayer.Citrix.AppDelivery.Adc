﻿using CoreLayer.Citrix.AppDelivery.Adc.NitroCommon;
using CoreLayer.Citrix.AppDelivery.Adc.NitroInterfaces;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CoreLayer.Citrix.AppDelivery.Adc.NitroApi
{
    /// <summary>
    /// TODO NitroRequestSerializer
    /// </summary>
    public static class NitroRequestSerializer
    {
        private static async Task SerializeRequestData(Stream dataStream, INitroRequestDataRoot requestDataRoot)
        {
            await JsonSerializer.SerializeAsync(
                dataStream,
                requestDataRoot,
                requestDataRoot.GetType(),
                NitroSerializerOptions.JsonSerializerOptions,
                CancellationToken.None).ConfigureAwait(false);

            dataStream.Seek(0, SeekOrigin.Begin);
        }




        /// <summary>
        /// TODO StreamContent
        /// </summary>
        /// <param name="dataStream"></param>
        /// <returns></returns>
        private static StreamContent StreamContent(Stream dataStream) =>
            new StreamContent(new StreamReader(dataStream).BaseStream);




        /// <summary>
        /// TODO GenerateHttpRequestMessageAsync
        /// </summary>
        /// <param name="requestConfiguration"></param>
        /// <returns></returns>
        public static async Task<HttpRequestMessage> GenerateHttpRequestMessageAsync(INitroRequest requestConfiguration)
        {
            var dataStream = new MemoryStream();
            await SerializeRequestData(dataStream, requestConfiguration.DataRoot).ConfigureAwait(false);

            var request = new HttpRequestMessage(
                requestConfiguration.Method,
                requestConfiguration.ResourcePath + requestConfiguration.Options.ToString())
            {
                Content = StreamContent(dataStream)
            };
            request.Content.Headers.ContentType = requestConfiguration.ContentType;

            return request;
        }
    }
}
