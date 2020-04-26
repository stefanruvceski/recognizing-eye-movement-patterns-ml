using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GazePointCommon
{
    [ServiceContract]
    public interface IGazePoint
    {
        [OperationContract]
        void StartRecording(int q);

        [OperationContract]
        void StopRecording(int a);

        [OperationContract]
        void ChangeQuestion(int ans, int q);
    }
}
