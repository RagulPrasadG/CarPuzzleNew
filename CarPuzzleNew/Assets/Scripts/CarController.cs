using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CarController : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] GameObject carPrefab;
    [SerializeField] float carMoveSpeed;
    private GameObject carClone;

    private bool canMove = true;

    public LevelDataSO levelDataSO;

    private void Update()
    {
        MoveCar();
    }

    private void Start()
    {
       
        SpawnCar();
    }
    private void MoveCar()
    {
        if (carClone == null) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
          
            if (!canMove) return;

            Vector3 endPosition = grid.GetUpEndPosition();
            Vector3 direction = (endPosition - carClone.transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(carClone.transform.DORotateQuaternion(rotation, 1f));
            sequence.Append(carClone.transform.DOMove(endPosition, 3f));
            sequence.Play();
            canMove = false;
            sequence.onComplete += () => canMove = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!canMove) return;
            Vector3 endPosition = grid.GetDownEndPosition();
            Vector3 direction = (endPosition - carClone.transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(carClone.transform.DORotateQuaternion(rotation, 1f));
            sequence.Append(carClone.transform.DOMove(endPosition, 3f));
            sequence.Play();
            canMove = false;
            sequence.onComplete += () => canMove = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!canMove) return;
            Vector3 endPosition = grid.GetRightEndPosition();
            Vector3 direction = (endPosition - carClone.transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(carClone.transform.DORotateQuaternion(rotation, 1f));
            sequence.Append(carClone.transform.DOMove(endPosition, 3f));
            sequence.Play();
            canMove = false;
            sequence.onComplete += () => canMove = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!canMove) return;
            Vector3 endPosition = grid.GetLeftEndPosition();
            Vector3 direction = (endPosition - carClone.transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(carClone.transform.DORotateQuaternion(rotation, 1f));
            sequence.Append(carClone.transform.DOMove(endPosition, 3f));
            sequence.Play();
            canMove = false;
            sequence.onComplete += () => canMove = true;
        }


    }

  
    private void SpawnCar()
    {
      carClone = Instantiate(carPrefab, grid.GetCellCenter(grid.GetCellPosition(grid.HorizontalIndex, grid.VerticalIndex)), Quaternion.identity);  
    }
}
