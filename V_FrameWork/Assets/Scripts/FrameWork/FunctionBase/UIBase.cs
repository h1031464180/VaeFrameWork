
using Vae.Manager;

namespace Vae
{
    public class UIBase : MonoBase
    {
        public ushort[] msgId;

        public void RegistSelf(MonoBase mono, params ushort[] msgs)
        {
            UIManager.Instance.RegistMsg(mono, msgs);
        }

        public void UnRegistSelf(params ushort[] msgs)
        {
            UIManager.Instance.UnRegistMsg(this, msgs);
        }

        public void SendMsg(MsgBase tmpMsg)
        {
            UIManager.Instance.SendMsg(tmpMsg);
        }

        private void OnDestroy()
        {
            if (msgId != null)
            {
                UnRegistSelf(msgId);
            }
        }

    }
}