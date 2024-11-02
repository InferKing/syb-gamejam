using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllItemsView : MonoBehaviour
{
    [SerializeField]
    private ContentSizeFitter _fitter;
    [SerializeField]
    private ItemViewTerminal _itemTerminalPrefab;

    private List<ItemViewTerminal> _items = new();

    public void Init()
    {
        AllItems items = ServiceLocator.Instance.Get<AllItems>();
        foreach (var item in items.items) 
        { 
            GameObject gObj = Instantiate(_itemTerminalPrefab.gameObject);
            gObj.transform.SetParent(_fitter.transform, false);
            var view = gObj.GetComponent<ItemViewTerminal>();
            view.SetView(item);
            _items.Add(view);
        }
    }

    public void Show()
    {
        foreach (var item in _items) 
        { 
            item.UpdateView();
        }
        //foreach (var item in ServiceLocator.Instance.Get<PickedItems>().PlayerPickedItems) 
        //{
        //    foreach (var view in _items)
        //    {
        //        if (item == view.Data)
        //        {
        //            view.SetComplete();
        //        }
        //        view.UpdateView();
        //    }
        //}
        //foreach (var item in ServiceLocator.Instance.Get<PickedItems>().Items)
        //{
        //    foreach (var view in _items)
        //    {
        //        if (item == view.Data)
        //        {
        //            view.Toggle(true);
        //        }
        //        view.UpdateView();
        //    }
        //}

    }
}
