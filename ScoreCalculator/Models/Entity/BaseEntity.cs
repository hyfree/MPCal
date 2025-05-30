﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ScoreCalculator.Common.Converter.JsonConverter;

namespace ScoreCalculator.Models.Entity
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        [JsonConverter(typeof(LeanoteLongNullableJsonConverter))]
        public long Id { get; set; }

        /// <summary>确定指定对象是否等于当前对象。</summary>
        /// <param name="obj">要与当前对象进行比较的对象。</param>
        /// <returns>如果指定的对象等于当前对象，则为 <see langword="true" />；否则为 <see langword="false" />。</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType())
            {
                return Id == ((BaseEntity)obj).Id;
            }

            return false;
        }

        /// <summary>作为默认哈希函数。</summary>
        /// <returns>当前对象的哈希代码。</returns>
        public override int GetHashCode()
        {
            return (int)Id;
        }
    }
}
