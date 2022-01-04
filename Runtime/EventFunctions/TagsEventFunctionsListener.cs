using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ScriptableObjectArchitecture.EventFunctions
{
    public abstract class TagsEventFunctionsListener : EventListener
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;

        protected void Invoke(Collision other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke();
                }
            }
        }

        protected void Invoke(Collider other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke();
                }
            }
        }

        protected void Invoke(Collision2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke();
                }
            }
        }

        protected void Invoke(Collider2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke();
                }
            }
        }
    }

    public abstract class TagsEventFunctionsListener<T0> : EventListener<T0>
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;

        protected void Invoke(Collision other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke(args0);
                }
            }
        }

        protected void Invoke(Collider other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke(args0);
                }
            }
        }

        protected void Invoke(Collision2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke(args0);
                }
            }
        }

        protected void Invoke(Collider2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke(args0);
                }
            }
        }
    }
}
