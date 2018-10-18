﻿using System.Web;
using System.Web.UI;
using Sitecore.Foundation.RankingFoundry.Configuration;

namespace Sitecore.Foundation.RankingFoundry.ControlPanel.Controls
{
	/// <summary>
	/// Allows performing the initial serialization of an empty configuration.
	/// </summary>
	internal class InitialSetup : IControlPanelControl
	{
		private readonly IConfiguration _configuration;

		public InitialSetup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Render(HtmlTextWriter writer)
		{
			writer.Write("<h4>Initial Setup</h4>");

			var invalidRootPaths = ControlPanelUtility.GetInvalidRootPaths(_configuration);

			if (invalidRootPaths.Length == 0)
			{
				writer.Write("<p>Would you like to perform an initial serialization of all configured items using the options outlined above now? This is required to start using this configuration.</p>");

				writer.Write("<a class=\"button\" href=\"?verb=Reserialize&amp;configuration={0}\">Perform Initial Serialization of <em>{1}</em></a>", HttpUtility.UrlEncode(_configuration.Name), _configuration.Name);
			}
			else
			{
				writer.Write("<div class=\"warning\"><p>Cannot perform initial serialization because the predicate configuration is including item paths which do not exist in the database. The following path(s) are invalid:</p>");
				writer.Write("<ul>");
				foreach (var root in invalidRootPaths)
				{
					writer.Write($"<li>{root}</li>");
				}
				writer.Write("</ul></div>");
			}
		}
	}
}
