using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScriptableObjectArchitecture.EventFunctions
{
    public abstract class TagsEventFunctionsListener : EventListener
    {
        [SerializeField]
        protected FilterObject Filter;

        private List<GameObject> results;

        private Task<List<GameObject>> task;

        protected virtual void Start()
        {
            task = Filter.RunFilterAsync();
        }

        protected async void Invoke(Collision other)
        {
            results = await task;
            if (results.Contains(other.gameObject))
            {
                Response.Invoke();
            }
        }

        protected async void Invoke(Collider other)
        {
            results = await task;
            if (results.Contains(other.gameObject))
            {
                Response.Invoke();
            }
        }

        protected async void Invoke(Collision2D other)
        {
            results = await task;
            if (results.Contains(other.gameObject))
            {
                Response.Invoke();
            }
        }

        protected async void Invoke(Collider2D other)
        {
            results = await task;
            if (results.Contains(other.gameObject))
            {
                Response.Invoke();
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
                    Invoke();
                }
            }
        }

        protected void Invoke(Collider other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collision2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collider2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        private void Invoke()
        {
            for (int j = 0; j < Responses.Count; j++)
            {
                Responses[j].Response.Invoke(Responses[j].args0);
            }
        }
    }

    public abstract class TagsEventFunctionsListener<T0, T1> : EventListener<T0, T1>
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;

        protected void Invoke(Collision other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collider other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collision2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collider2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        private void Invoke()
        {
            for (int j = 0; j < Responses.Count; j++)
            {
                Responses[j].Response.Invoke(Responses[j].args0, Responses[j].args1);
            }
        }
    }

    public abstract class TagsEventFunctionsListener<T0, T1, T2> : EventListener<T0, T1, T2>
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;

        protected void Invoke(Collision other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collider other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collision2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collider2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        private void Invoke()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0, Responses[i].args1, Responses[i].args2);
            }
        }
    }

    public abstract class TagsEventFunctionsListener<T0, T1, T2, T3> : EventListener<T0, T1, T2, T3>
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;

        protected void Invoke(Collision other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collider other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collision2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        protected void Invoke(Collider2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Invoke();
                }
            }
        }

        private void Invoke()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0, Responses[i].args1, Responses[i].args2, Responses[i].args3);
            }
        }
    }
}
