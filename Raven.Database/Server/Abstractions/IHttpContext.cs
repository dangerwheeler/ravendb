//-----------------------------------------------------------------------
// <copyright file="IHttpContext.cs" company="Hibernating Rhinos LTD">
//     Copyright (c) Hibernating Rhinos LTD. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.IO;
using System.Security.Principal;
using NLog;

namespace Raven.Database.Server.Abstractions
{
	public interface IHttpContext
	{
		bool RequiresAuthentication { get; }
		IRavenHttpConfiguration Configuration { get; }
		IHttpRequest Request { get; }
		IHttpResponse Response { get; }
		IPrincipal User { get; set; }
		string GetRequestUrlForTenantSelection();
		void FinalizeResonse();
		void SetResponseFilter(Func<Stream, Stream> responseFilter);
		void OutputSavedLogItems(Logger logger);
		void Log(Action<Logger> loggingAction);
	}
}
