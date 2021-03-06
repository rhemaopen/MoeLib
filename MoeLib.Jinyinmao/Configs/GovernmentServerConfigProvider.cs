﻿using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Configs.GovernmentHttpClient;

namespace MoeLib.Jinyinmao.Configs
{
    /// <summary>
    ///     GovernmentServerConfigProvider.
    /// </summary>
    /// <typeparam name="TConfig">The type of the t configuration.</typeparam>
    public class GovernmentServerConfigProvider<TConfig> : IConfigProvider where TConfig : class, IConfig
    {
        private static readonly Lazy<HttpClient> httpClient = new Lazy<HttpClient>(() => InitHttpClient());

        private HttpClient HttpClient
        {
            get { return httpClient.Value; }
        }

        #region IConfigProvider Members

        /// <summary>
        ///     Gets the type of the configuration.
        /// </summary>
        /// <returns>Type.</returns>
        public Type GetConfigType()
        {
            return typeof(TConfig);
        }

        /// <summary>
        ///     Gets the configurations string.
        /// </summary>
        /// <returns>System.String.</returns>
        public SourceConfig GetSourceConfig()
        {
            try
            {
                ApplicationConfigurationsFetchRequest request = new ApplicationConfigurationsFetchRequest
                {
                    Role = App.Host.Role,
                    RoleInstance = App.Host.RoleInstance,
                    SourceVersion = App.Configurations.GetConfigurationVersion()
                };
                return Task.Run(async () =>
                {
                    HttpResponseMessage response = await this.HttpClient.PostAsJsonAsync("/api/Configurations", request);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return content.FromJson<SourceConfig>();
                    }
                    throw new HttpRequestException($"Can not get \"Configurations\" from government server {this.HttpClient.BaseAddress}, {response.StatusCode} {response.ReasonPhrase}");
                }).Result;
            }
            catch (Exception e)
            {
                throw new ConfigurationErrorsException("Missing config of \"Configurations\"", e);
            }
        }

        #endregion IConfigProvider Members

        private static Uri GetGovernmentBaseUri()
        {
            try
            {
                string specifiedGovernmentBaseUri = CloudConfigurationManager.GetSetting("GovernmentBaseUri");
                if (specifiedGovernmentBaseUri.IsNotNullOrEmpty() && RegexUtility.UrlRegex.IsMatch(specifiedGovernmentBaseUri))
                {
                    Uri governmentBaseUri = new Uri(specifiedGovernmentBaseUri);
                    return governmentBaseUri;
                }
            }
            catch
            {
                // ignored
            }

            return new Uri($"http://jym-{App.Host.Environment.ToLowerInvariant()}-government.jinyinmao.com.cn/");
        }

        private static HttpClient InitHttpClient()
        {
            HttpClient client = HttpClientFactory.Create(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }, new GovernmentHttpClientMessageHandler());
            client.BaseAddress = GetGovernmentBaseUri();
            client.Timeout = 1.Minutes();
            return client;
        }
    }
}