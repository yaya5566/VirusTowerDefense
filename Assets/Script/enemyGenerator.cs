using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Events;

public class enemyGenerator : MonoBehaviour
{

    private class patientDataObject{
        public string patientTag;
        public float nextPatientTime=0f;
    }

    private class waveDataObject{
        public float nextWaveTime =0f;
        public int initEnergy=0;
        int nowPatientNo=1;
        private Dictionary<int,patientDataObject> Rounds=new Dictionary<int, patientDataObject>();
        public void newPatient(int patientNo,patientDataObject patientData){
            Rounds.Add(patientNo,patientData);
            return;
        }
        public bool getAndRemovePatient(out patientDataObject patient){
            bool isOk =Rounds.TryGetValue(nowPatientNo,out patient);
            Rounds.Remove(nowPatientNo);
            nowPatientNo++;
            return isOk;
        }     
        public float getNextPatientTime(){
            patientDataObject patient;
            Rounds.TryGetValue(nowPatientNo,out patient);
            return patient.nextPatientTime;
        }       
        public bool isEnd(){
            return Rounds.Count==0;
        } 
    }   


    // Start is called before the first frame update
    private Dictionary<int,waveDataObject> waveData=new Dictionary<int, waveDataObject>();
    public List<GameObject> Enemies;
    private float walkableFloor = 1.2f;
    private float walkableCiel = -1.2f;
    private bool isState = false; // 0 = pause
    int nowWave=1;
    private int patientAmount = 0;
    private float waitTime=0f;
    private int energy=0;

    [SerializeField]
    private GameObject patient_NewVirus;
    [SerializeField]
    private GameObject patient_BlueMask;
    [SerializeField]
    private GameObject patient_RadSyringe;
    [SerializeField]
    private GameObject patient_YellowPill;

    void Start()
    {
        waveDataInit();
        Init();
    }

    // Update is called once per frame


    void Init() 
    {
        if (!getWaveEnergy()){
            return;
        }
        gameManager.Instance.addIEnergy(energy);
        patientAmount = 0;
        foreach(var enemy in Enemies)
            Destroy(enemy);
        Enemies.Clear();
        isState = true;
        Generate();
    }
    void Wait()
    {
        if (isAllWaveEnd()){
            return;
        }
        if (isWaveEnd()){
            Invoke("Init", waitTime);
        }else{
            Invoke("Generate", waitTime);
        }
    }
    void Generate()
    {
        if(isState) {
            GameObject patientItem;
            if (!getNextPatient(out patientItem)){
                return;
            }
            GameObject GoPatitentItem = UnityEngine.Object.Instantiate<GameObject>(patientItem, transform);
            float patientY = Random.Range(walkableFloor, walkableCiel);
            GoPatitentItem.name = GoPatitentItem.tag+"_" + patientAmount;
            GoPatitentItem.transform.position = new Vector3(transform.position.x, patientY, 0);
            Enemies.Add(GoPatitentItem);
            patientAmount++;
            Wait();
        }
    }

    bool isAllWaveEnd(){
        return waveData.Count==0;
    }
    bool isWaveEnd(){
        waveDataObject tempWaveData;
        bool end=true;
        if (waveData.TryGetValue(nowWave,out tempWaveData)){
            end=tempWaveData.isEnd();
        }
        if (end){
            waitTime=tempWaveData.nextWaveTime;
            waveData.Remove(nowWave);
            nowWave++;
        }else{
            waitTime=tempWaveData.getNextPatientTime();
        }
        return end;
    }

    bool getNextPatient(out GameObject patient){
                waveDataObject tempWaveData;
                patientDataObject info;
                while (true){
                    if (waveData.TryGetValue(nowWave,out tempWaveData)){
                        if(tempWaveData.getAndRemovePatient(out info)){
                            break;
                        }
                    }
                    waveData.Remove(nowWave);
                    nowWave++;
                    if (isAllWaveEnd()){
                        patient=patient_NewVirus;
                        return false;
                    }
                }
                switch (info.patientTag){
                    case "BlueMask":
                        patient= patient_BlueMask;
                        break;
                    case "RadSyringe":
                        patient= patient_RadSyringe;
                        break;
                    case "YellowPill":
                        patient= patient_YellowPill;
                        break;
                    default:
                        patient= patient_NewVirus;
                        break;
                }
                return true;
    }

    bool getWaveEnergy(){
        waveDataObject tempWaveData;
        while (true){
            if (waveData.TryGetValue(nowWave,out tempWaveData)){
                energy=tempWaveData.initEnergy;
                return true;
            }
            waveData.Remove(nowWave);
            nowWave++;
            if (isAllWaveEnd()){
                energy=0;
                return false;
            }
        }
    }

    void waveDataInit(){
        waveDataObject tempWaveData = new waveDataObject();
        int nowPatientNo=1;
        int nowWaveNo=1;
        tempWaveData.nextWaveTime=3f;
        tempWaveData.initEnergy=80;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="BlueMask",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="RadSyringe",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="YellowPill",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="NewVirus",nextPatientTime=2f});
        nowPatientNo++;
        waveData.Add(nowWaveNo,tempWaveData);
        nowWaveNo++;

        nowPatientNo=1;
        tempWaveData = new waveDataObject();
        tempWaveData.nextWaveTime=3f;
        tempWaveData.initEnergy=50;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="BlueMask",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="RadSyringe",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="YellowPill",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="NewVirus",nextPatientTime=2f});
        nowPatientNo++;
        waveData.Add(nowWaveNo,tempWaveData);
        nowWaveNo++;


        nowPatientNo=1;
        tempWaveData = new waveDataObject();
        tempWaveData.nextWaveTime=3f;
        tempWaveData.initEnergy=50;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="BlueMask",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="RadSyringe",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="YellowPill",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="NewVirus",nextPatientTime=2f});
        nowPatientNo++;
        waveData.Add(nowWaveNo,tempWaveData);
        nowWaveNo++;


        nowPatientNo=1;
        tempWaveData = new waveDataObject();
        tempWaveData.nextWaveTime=3f;
        tempWaveData.initEnergy=50;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="BlueMask",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="RadSyringe",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="YellowPill",nextPatientTime=2f});
        nowPatientNo++;
        tempWaveData.newPatient(nowPatientNo,new patientDataObject(){patientTag="NewVirus",nextPatientTime=2f});
        nowPatientNo++;
        waveData.Add(nowWaveNo,tempWaveData);
        nowWaveNo++;

    }
}