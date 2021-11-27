namespace ScriptableObjectArchitecture
{
    public class AudioEventListener : GameEventListener<AudioEvent>
    {
        protected override void OnEnable()
        {
            GameEvent.Register(this);
        }

        protected override void OnDisable()
        {
            GameEvent.Unregister(this);
        }
    }
}