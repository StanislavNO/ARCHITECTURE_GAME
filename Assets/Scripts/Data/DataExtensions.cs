﻿using UnityEngine;

namespace Assets.Scripts.Data
{
    public static class DataExtensions
    {
        public static Vector3 AddY(this Vector3 position, float heightAddition)
        {
            position.y = heightAddition;
            return position;
        }

        public static Vector3Data AsVectorData(this Vector3 vector) =>
            new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
            new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static T ToDeserialised<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
    }
}