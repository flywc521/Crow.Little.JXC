using Crow.Little.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crow.Little.JXC
{
    /// <summary>
    /// ���Ĳ���ҵ��
    /// </summary>
    public static class MajorOperator
    {
        #region Field
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        public static event EventHandler<CommonEventArgs<AppStep>> ApplicationInitStepChanged;
        #endregion
        #region Method
        public static void InitiateApplication()
        {
            //֪ͨ��ʼ�����
            if (ApplicationInitStepChanged != null)
            {
                ApplicationInitStepChanged(null, new CommonEventArgs<AppStep>(new AppStep(100, 100, String.Empty)));
            }
        }

        public static void CloseApplication()
        {
            //��ո�����Դ�ĵ���
        }
        #endregion
    }
}
