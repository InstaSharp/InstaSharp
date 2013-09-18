using System;
using System.Collections.Generic;
namespace InstaSharp.Models.Responses {
    public interface IResponse {
        InstaSharp.Models.Meta Meta { get; set; }
    }
}
