﻿using System.Net;
using System.Web;

namespace Sitecore.Foundation.RankingFoundry.ControlPanel.Security
{
	public interface IUnicornAuthenticationProvider
	{
		string GetChallengeToken();
		SecurityState ValidateRequest(HttpRequestBase request);
		WebClient CreateAuthenticatedWebClient(string remoteUnicornUrl);
	}
}
