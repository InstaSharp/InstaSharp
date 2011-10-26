using System;
using System.Collections.Generic;
namespace InstaSharp.Model.Responses {
    public interface IResponse {
        string Json { get; set; }
        InstaSharp.Model.Meta Meta { get; set; }
    }
}
