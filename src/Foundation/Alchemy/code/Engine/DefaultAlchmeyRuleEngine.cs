﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Sitecore.Diagnostics;
using Sitecore.Foundation.AlchemyBase;

namespace Sitecore.Foundation.Alchemy.Engine
{
	public class DefaultAlchmeyRuleEngine : IDefaultAlchmeyRuleEngine
	{
		protected readonly List<IAlchemyRule> AlchemyRules = new List<IAlchemyRule>();

		public DefaultAlchmeyRuleEngine(XmlNode configNode)
		{
			Assert.ArgumentNotNull(configNode, "configNode");

			var rules = configNode.ChildNodes;

			foreach (XmlNode rule in rules)
			{
				if (rule.NodeType == XmlNodeType.Element && rule.Name.Equals("alchemyRule"))
				{
					FieldComparers.Add(XmlActivator.CreateObject<IFieldComparer>(comparer));
				}
			}

			FieldComparers.Add(new DefaultComparison());
		}
	}
}