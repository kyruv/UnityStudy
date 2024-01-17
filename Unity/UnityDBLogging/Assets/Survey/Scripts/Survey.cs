using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using MyBox;

namespace SurveyRuntime
{
    public class Survey : MonoBehaviour
    {
        [Header("Survey Data")]
        [SerializeField] private Page[] pages;

        void Start()
        {
            foreach (Page p in pages)
            {
                p.FlashPresets();
            }
        }

        void Update()
        {

        }
    }

    [System.Serializable]
    public class Page
    {
        public string page_title;

        public Question[] questions;

        public void FlashPresets()
        {
            foreach (Question q in questions)
            {
                q.FlashPresets();
            }
        }

    }

    [System.Serializable]
    public class Question
    {
        [System.Serializable]
        public enum QuestionType
        {
            SCALE,
            FREE_TEXT
        }

        public QuestionType type;

        public void FlashPresets()
        {
            scaleQuestion.FlashPresets();
            freeTextQuestion.FlashPresets();
        }

        [ConditionalField(nameof(type), false, QuestionType.SCALE)] public ScaleQuestion scaleQuestion;
        [ConditionalField(nameof(type), false, QuestionType.FREE_TEXT)] public FreeTextQuestion freeTextQuestion;
    }

    [System.Serializable]
    public class ScaleQuestion
    {
        [System.Serializable]
        public enum Range
        {
            ONE_THRU_SEVEN,
            ONE_THRU_FIVE,
            CUSTOM
        }

        [System.Serializable]
        public enum Labels
        {
            DISAGREE_AGREE,
            CUSTOM
        }


        [Header("Question")]
        public string question;

        [Header("Config")]
        public Range range;
        public Labels labels;

        [ConditionalField(nameof(range), false, Range.CUSTOM)] public int range_low;
        [ConditionalField(nameof(range), false, Range.CUSTOM)] public int range_high;
        [ConditionalField(nameof(range), false, Range.CUSTOM)] public float range_delta;

        [ConditionalField(nameof(labels), false, Labels.CUSTOM)] public string label_low;
        [ConditionalField(nameof(labels), false, Labels.CUSTOM)] public string label_high;

        public void FlashPresets()
        {
            switch (range)
            {
                case Range.ONE_THRU_SEVEN:
                    range_low = 1;
                    range_high = 7;
                    range_delta = 1;
                    break;
                case Range.ONE_THRU_FIVE:
                    range_low = 1;
                    range_high = 5;
                    range_delta = 1;
                    break;
            }

            switch (labels)
            {
                case Labels.DISAGREE_AGREE:
                    label_low = "Strongly Disagree";
                    label_high = "Strongly Agree";
                    break;
            }
        }
    }

    [System.Serializable]
    public class FreeTextQuestion
    {
        [System.Serializable]
        public enum Size
        {
            PARAGRAPH,
            SENTENCE,
            CUSTOM
        }

        [Header("Question")]
        public string question;

        [Header("Config")]
        public Size size;
        [ConditionalField(nameof(size), false, Size.CUSTOM)] public int word_limit;

        public void FlashPresets()
        {
            switch (size)
            {
                case Size.PARAGRAPH:
                    word_limit = 1000;
                    break;
                case Size.SENTENCE:
                    word_limit = 100;
                    break;
            }
        }
    }
}

