/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MouseControls : MonoBehaviour
{
    [SerializeField]
    Transform SelectionAreaTransform = null; 
    Vector3 StartPosition = Vector3.zero;
    [SerializeField]
    List<PlayPiece> SelectedPieces;

    private void Awake()
    {
        SelectedPieces = new List<PlayPiece>();
        SelectionAreaTransform.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //When Left Mouse Button Down
            SelectionAreaTransform.gameObject.SetActive(true);
            StartPosition = UtilsClass.GetMouseWorldPosition();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {

                if (hit.transform.GetComponent<County>())
                {

                    County county = hit.transform.GetComponent<County>();

                    CountyDetails.Instance.ActiveSwitch(true);
                    CountyDetails.Instance.SelectedCounty = county; 
                    CountyDetails.Instance.Name.text = county.name;
                    if (county.Owner != null)
                    {
                        CountyDetails.Instance.Owner.text = county.Owner.FactionTag;
                        RecruitDetails.Instance.ActiveSwitch(county.Owner.isPlayer);
                    }
                    else
                    {
                        RecruitDetails.Instance.ActiveSwitch(false);
                        CountyDetails.Instance.Owner.text = "Self Claimed";
                    }

                    CountyDetails.Instance.Terrain.text = county.TerrainType + "";
                    CountyDetails.Instance.Level.text = "Level: " + county.Infrustructure_Rating;

                    RecruitDetails.Instance.CleanButton();
                    RecruitDetails.Instance.AddButtonAction(county.GetComponent<UnitRecruitmentObject>());
                    RecruitDetails.Instance.RecruitImage.sprite = county.GetComponent<UnitRecruitmentObject>().CurrentlyRecruiting1 ? county.GetComponent<UnitRecruitmentObject>().CurrentlyRecruiting1.Singa : null;
                }

                else
                {
                    foreach (PlayPiece piece in SelectedPieces)
                    {
                        piece.IsSelected = false;
                    }
                    CountyDetails.Instance.ActiveSwitch(false);
                    ArmyDetailsPanel.Instance.ActiveSwitch(false);
                }

            }

           // Debug.Log(SelectedPieces.Count);
        }
        

        if (Input.GetMouseButton(0))
        {

            foreach (PlayPiece piece in SelectedPieces)
            {
                piece.IsSelected = false;
            }

            //While Left Mouse Button is Down
            Vector3 CurrentMousePostion = UtilsClass.GetMouseWorldPosition();
            
            Vector3 lowerLeft = new Vector3(
                Mathf.Min(StartPosition.x, CurrentMousePostion.x),
                Mathf.Min(StartPosition.y, CurrentMousePostion.y));
            Vector3 UpperRight = new Vector3(
                Mathf.Max(StartPosition.x, CurrentMousePostion.x),
                Mathf.Max(StartPosition.y, CurrentMousePostion.y));
            SelectionAreaTransform.position = lowerLeft;
            SelectionAreaTransform.localScale = UpperRight - lowerLeft; //Shows the area of selection
        }

        if (Input.GetMouseButtonUp(0))
        {
            //On Left Mouse Release
            SelectionAreaTransform.gameObject.SetActive(false);

            Collider2D[] collider2Darray = Physics2D.OverlapAreaAll(StartPosition, UtilsClass.GetMouseWorldPosition());

            SelectedPieces.Clear();

            foreach (Collider2D cd2D in collider2Darray)
            {// Collider Collection
                PlayPiece piece = cd2D.GetComponent<PlayPiece>();
                if(piece != null && piece.Owner.isPlayer)
                {//Adds units to selection Array if it belongs to the player
                    SelectedPieces.Add(piece);
                    piece.IsSelected = true;
                }
            }
            
            foreach (PlayPiece piece in SelectedPieces)
            {
                ArmyDetailsPanel.Instance.ActiveSwitch(true);
                ArmyDetails.Instance.SelectedArmy = piece.transform.GetComponent<Army>();
                if (SelectedPieces.Count == 1)
                {
                    ArmyDetails.Instance.UpdateCard();
                }
                else
                {
                    ArmyDetails.Instance.UpdateCard(SelectedPieces);
                }
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            //On Right Mouse Down
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {

                if (hit.transform.GetComponent<County>())
                {//On Selection of a county
                    
                    foreach (PlayPiece piece in SelectedPieces)
                    {//If there are pieces selected
                        Pathfinding Path = new Pathfinding();
                        PieceMovement Movement = piece.GetComponent<PieceMovement>();
                        Movement.ResetPathIterator();
                        Movement.CurrentDestination = hit.transform.GetComponent<County>().Node;

                        Movement.CurrentPath = Path.FindPath(Movement.CurrentPosition, Movement.CurrentDestination);

                        Movement.SetActiveTick(hit.transform.GetComponent<County>().Node);
                    }
                }
            }
        }
    }
}
