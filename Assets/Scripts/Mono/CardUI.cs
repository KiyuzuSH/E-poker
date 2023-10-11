using ObjPool;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
	/// <summary> ������Ϊ�� </summary>
	public class CardUI : ReuseableObject, IPointerClickHandler
	{
		/// <summary> ������ʾ��ͼƬ </summary>
		public Image image;
		private Card card;
		private bool isSelected;

		/// <summary> ������Ϣ </summary>
		public Card Card
		{
			get { return card; }
			set
			{
				card = value;
				SetImage();
			}
		}

		/// <summary> ������� </summary>
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

		/// <summary> �Ƿ�ѡ�� </summary>
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

		/// <summary> ����¼� </summary>
		/// <param name="eventData"></param>
		public void OnPointerClick(PointerEventData eventData)
		{
			if(eventData.button == PointerEventData.InputButton.Left)
				if(card.BelongTo == CharacterType.PlayerC)
					Selected = !Selected;
		}

		/// <summary> ���ٿ��� </summary>
		public void Destroy()
		{
			PoolManager.Instance.HideObjet(gameObject);
		}

		/// <summary> �ɸ���������ÿ�δ���ʱ���� </summary>
		public override void BeforeGetObject()
		{
			image = GetComponent<Image>();
		}

		/// <summary> �ɸ���������ÿ������ʱ���� </summary>
		public override void BeforeHideObject()
		{
			isSelected = false;
			image.sprite = null;
			card = null;
		}

		/// <summary> �����Ƶ�λ�� </summary>
		/// <param name="parent"> ���ڵ� </param>
		/// <param name="index"> ���� </param>
		public void SetPosition(Transform parent, int index)
		{
			transform.SetParent(parent, false);
			transform.SetSiblingIndex(index);
			// �ұ�
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
