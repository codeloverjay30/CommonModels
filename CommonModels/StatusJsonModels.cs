using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class StatusJsonModels
    {
        public List<StatusJsonModel> StatusList { get; set;} = new List<StatusJsonModel>();

        public bool IsAllSuccess => !HasNoneStatus && StatusList.All(statusModel => statusModel.IsSuccess);
        public bool IsAllFailure => !HasNoneStatus && StatusList.All(statusModel => !statusModel.IsSuccess);

        public bool HasNoneStatus => StatusList.Count == 0;
    }
}
