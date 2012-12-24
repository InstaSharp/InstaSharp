using System;
using System.Collections.Generic;
namespace InstaSharp.Model.Responses {
    public interface IResponse {
        InstaSharp.Model.Meta Meta { get; set; }
    }
}
