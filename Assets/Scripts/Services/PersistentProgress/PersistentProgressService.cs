using Assets.Scripts.Data;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}