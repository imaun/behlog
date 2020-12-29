using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Services.Contracts.Http {
    public interface ILinkBuilder {

        string BuildFromRoute(string routeName, object routeValues);
        bool UrlIsValid(string url);
    }
}
