﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEditor;
using Rotorz.ReorderableList;
using System;
using Ntreev.Library.Psd;
using PSDUnity.Data;
using PSDUnity.Import;

namespace PSDUnity.Exprot
{
    [CustomEditor(typeof(AtlasObject))]
    public class AtlasObjectDrawer : Editor
    {
        SerializedProperty scriptProp;
        SerializedProperty psdFileProp;
        SerializedProperty uiSizeProp;
        SerializedProperty groupsProp;
        SerializedProperty exportInfoProp;
        SerializedProperty prefabObjProp;
        SerializedProperty forceSpriteProp;
        AtlasObject atlasObj;
        readonly GUIContent pageSizeContent = new GUIContent("界面尺寸", EditorGUIUtility.IconContent("AnimationKeyframeBackground").image, "界面尺寸");
        private void OnEnable()
        {
            atlasObj = target as AtlasObject;
            scriptProp = serializedObject.FindProperty("m_Script");
            psdFileProp = serializedObject.FindProperty("psdFile");
            uiSizeProp = serializedObject.FindProperty("uiSize");
            groupsProp = serializedObject.FindProperty("groups");
            exportInfoProp = serializedObject.FindProperty("exportInfo");
            prefabObjProp = serializedObject.FindProperty("prefabObj");
            forceSpriteProp = serializedObject.FindProperty("forceSprite");
        }
        protected override void OnHeaderGUI()
        {
            base.OnHeaderGUI();
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.ObjectField(atlasObj, typeof(AtlasObject), false);
            EditorGUILayout.PropertyField(scriptProp);
            EditorGUI.EndDisabledGroup();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPageSize();
            DrawPictureData();
            DrawPictureOption();
            DrawGroupNode();
            DrawUICreateOption();
            DrawToolButtons();
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawUICreateOption()
        {
            EditorGUILayout.PropertyField(prefabObjProp, true);
            if (GUILayout.Button("创建规则"))
            {
                var obj = RouleObject.CreateInstance<RouleObject>();
                ProjectWindowUtil.CreateAsset(obj, "prefabObj.asset");
                prefabObjProp.objectReferenceValue = obj;
            }
        }

        private void DrawPictureData()
        {
            EditorGUILayout.PropertyField(exportInfoProp, true);
        }


        private void SwitchLayerToTexture()
        {
            if (!string.IsNullOrEmpty(atlasObj.psdFile))
            {
                var psd = PsdDocument.Create(atlasObj.psdFile);
                if (psd != null)
                {
                    PsdExportUtility.InitPsdExportEnvrioment(atlasObj.exportInfo, atlasObj.prefabObj,new Vector2(psd.Width,psd.Height));
                    atlasObj.groups.Clear();
                    var groupDatas = PsdExportUtility.CreatePictures(psd.Childs,new Vector2(psd.Width,psd.Height), atlasObj.uiSize, atlasObj.forceSprite);
                    if (groupDatas != null)
                    {
                        foreach (var groupData in groupDatas)
                        {
                            PsdExportUtility.ChargeTextures(atlasObj.exportInfo, groupData);
                            atlasObj.groups.Add(groupData);
                        }
                    }

                    EditorUtility.SetDirty(atlasObj);
                }
            }
        }


        private void DrawPageSize()
        {

            using (var hor = new EditorGUILayout.HorizontalScope())
            {
                psdFileProp.stringValue = EditorGUILayout.TextField("PSD路径：", psdFileProp.stringValue);

                if (GUILayout.Button("选择"))
                {
                    var psdPath = EditorUtility.OpenFilePanel("选择一个pdf文件", psdFileProp.stringValue, "psd");
                    if (!string.IsNullOrEmpty(psdPath))
                    {
                        psdFileProp.stringValue = psdPath;
                    }
                }
            }
            uiSizeProp.vector2Value = EditorGUILayout.Vector2Field(pageSizeContent, uiSizeProp.vector2Value);
        }
        private void DrawPictureOption()
        {
            EditorGUILayout.PropertyField(forceSpriteProp);
            if (GUILayout.Button("读取层级"))
            {
                SwitchLayerToTexture();
            }
        }
        private void DrawGroupNode()
        {
            ReorderableListGUI.Title("信息列表");
            ReorderableListGUI.ListField(groupsProp);
        }
        private void DrawToolButtons()
        {
            if (GUILayout.Button("导出到UI"))
            {
                var atlasObj = (AtlasObject)target;
                PSDImportUtility.InitEnviroment(atlasObj.prefabObj, atlasObj.uiSize);
                PSDImportCtrl import = new PSDImportCtrl();
                import.Import(atlasObj.groups.ToArray(),atlasObj.uiSize);
               
            }
        }
    }

}