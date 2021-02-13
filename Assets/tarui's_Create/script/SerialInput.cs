using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;
using System;

public class SerialInput : MonoBehaviour
{
    private SerialPort _device;
    private Thread _receiveThread;
    private byte[] receiveDataBuffer = new byte[256 * 4];
    private byte[] receiveDataBuffer2 = new byte[256 * 4];
    public string portName ="COM3";
    public int baudRate = 9600;
    private bool _isActive = false;

    void Awake()
    {
        Debug.LogWarning("Serial Start");

      //  for (int i = 0; i < 8; i++)
        {
            //_device = new SerialPort("COM"+i.ToString(), 115200);
            _device = new SerialPort(portName, baudRate);
            //Debug.Log(i.ToString()+_device.DtrEnable.ToString());
        }
        _device.Open();

        _receiveThread = new Thread(ReceiveFunc);
        _receiveThread.Start();
        _isActive = true;
    }

    void Start()
    {

    }

    void Update()
    {
        // C#のptrSwapの仕方を知らんのでとりあえずこれで
        Array.Copy(receiveDataBuffer2, receiveDataBuffer, receiveDataBuffer.Length);
    }

    void OnDestroy()
    {
        _device.Close();
        _isActive = false;
        _receiveThread.Join();
        _device.Dispose();
    }

    public int GetInteger(byte id)
    {
        return BitConverter.ToInt32(receiveDataBuffer, id * 4);
    }

    public string GetSrting(byte id)
    {
        Debug.Log(BitConverter.ToInt32(receiveDataBuffer, id * 0));
        Debug.Log(BitConverter.ToInt32(receiveDataBuffer, id * 1));
        Debug.Log(BitConverter.ToInt32(receiveDataBuffer, id * 2));
        Debug.Log(BitConverter.ToInt32(receiveDataBuffer, id * 3));
        return BitConverter.ToString(receiveDataBuffer, id * 4);
    }

    public float GetFloat(byte id)
    {
        return BitConverter.ToSingle(receiveDataBuffer, id * 4);
    }

    public void WriteCommand(string commandLine)
    {
        _device.WriteLine(commandLine);
    }

    private void ReceiveFunc()
    {
        byte[] buffer = new byte[5];
      

        while (_device.IsOpen && _isActive)
        {
            while (_device.BytesToRead < 5)
            {
                Thread.Sleep(1);
            }

            _device.Read(buffer, 0, 5);

            byte id = buffer[0];

            for(int i = 0; i < 4; i++)
            {
                receiveDataBuffer2[id * 4 + i] = buffer[1 + i];
            }
        }
    }
}
