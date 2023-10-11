using ObjPool;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
	/// <summary> 卡牌行为类 </summary>
	public class CardUI : ReuseableObject, IPointerClickHandler
	{
		/// <summary> 用来显示的图片 </summary>
		public Image image;
		private Card card;
		private bool isSelected;

		/// <summary> 卡牌信息 </summary>
		public Card Card
		{
			get { return card; }
			set
			{
				card = value;
				SetImage();
			}
		}

		/// <summary> 设置外观 </summary>
		private void SetImage()
		{
			Sprite s;
			if(card.BelongTo == CharacterType.PlayerC || card.BelongTo == CharacterType.Desk)
			{
				s = Resources.Load<Sprite>("Pokers/" + card.CardName);
				image.sprite = s;
			}
			else
			{
				s = Resources.Load<Sprite>("Pokers/CardBack");
				image.sprite = s;
			}
		}

		/// <summary> 是否被选中 </summary>
		public bool Selected
		{
			get { return isSelected; }
			set
			{
				if(value == isSelected) return;
				if(value == true)
					transform.localPosition += Vector3.up * 10;
				else
					transform.localPosition -= Vector3.up * 10;
				isSelected = value;
			}
		}

		/// <summary> 点击事件 </summary>
		/// <param name="eventData"></param>
		public void OnPointerClick(PointerEventData eventData)
		{
			if(eventData.button == PointerEventData.InputButton.Left)
				if(card.BelongTo == CharacterType.PlayerC)
					Selected = !Selected;
		}

		/// <summary> 销毁卡牌 </summary>
		public void Destroy()
		{
			PoolManager.Instance.HideObjet(gameObject);
		}

		/// <summary> 可复用物体在每次创建时调用 </summary>
		public override void BeforeGetObject()
		{
			image = GetComponent<Image>();
		}

		/// <summary> 可复用物体在每次销毁时调用 </summary>
		public override void BeforeHideObject()
		{
			isSelected = false;
			image.sprite = null;
			card = null;
		}

		/// <summary> 设置牌的位置 </summary>
		/// <param name="parent"> 父节点 </param>
		/// <param name="index"> 索引 </param>
		public void SetPosition(Transform parent, int index)
		{
			transform.SetParent(parent, false);
			transform.SetSiblingIndex(index);
			// 右边
			if(card.BelongTo == CharacterType.Desk || card.BelongTo == CharacterType.PlayerC)
			{
				transform.localPosition = Vector3.right * 35 * index;
				if(isSelected) transform.localPosition += Vector3.up * 10;
			}
			else if(card.BelongTo == CharacterType.PlayerL || card.BelongTo == CharacterType.PlayerR)
			{
				transform.localPosition = Vector3.up * -25 * index;
			}
		}

	}
}
