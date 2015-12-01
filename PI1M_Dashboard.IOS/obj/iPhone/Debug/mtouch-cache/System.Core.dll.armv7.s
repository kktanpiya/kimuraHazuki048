.subsections_via_symbols
.section __DWARF, __debug_abbrev,regular,debug

	.byte 1,17,1,37,8,3,8,27,8,19,11,17,1,18,1,16,6,0,0,2,46,1,3,8,135,64,8,58,15,59,15,17
	.byte 1,18,1,64,10,0,0,3,5,0,3,8,73,19,2,10,0,0,15,5,0,3,8,73,19,2,6,0,0,4,36,0
	.byte 11,11,62,11,3,8,0,0,5,2,1,3,8,11,15,0,0,17,2,0,3,8,11,15,0,0,6,13,0,3,8,73
	.byte 19,56,10,0,0,7,22,0,3,8,73,19,0,0,8,4,1,3,8,11,15,73,19,0,0,9,40,0,3,8,28,13
	.byte 0,0,10,57,1,3,8,0,0,11,52,0,3,8,73,19,2,10,0,0,12,52,0,3,8,73,19,2,6,0,0,13
	.byte 15,0,73,19,0,0,14,16,0,73,19,0,0,16,28,0,73,19,56,10,0,0,18,46,0,3,8,17,1,18,1,0
	.byte 0,0
.section __DWARF, __debug_info,regular,debug
Ldebug_info_start:

LDIFF_SYM0=Ldebug_info_end - Ldebug_info_begin
	.long LDIFF_SYM0
Ldebug_info_begin:

	.short 2
	.long 0
	.byte 4,1
	.asciz "Mono AOT Compiler 4.2.1 (mono-4.2.0-branch/6dd2d0d Thu Nov 12 12:59:52 EST 2015)"
	.asciz "System.Core.dll"
	.asciz ""

	.byte 2,0,0,0,0,0,0,0,0
LDIFF_SYM1=Ldebug_line_start - Ldebug_line_section_start
	.long LDIFF_SYM1
LDIE_I1:

	.byte 4,1,5
	.asciz "sbyte"
LDIE_U1:

	.byte 4,1,7
	.asciz "byte"
LDIE_I2:

	.byte 4,2,5
	.asciz "short"
LDIE_U2:

	.byte 4,2,7
	.asciz "ushort"
LDIE_I4:

	.byte 4,4,5
	.asciz "int"
LDIE_U4:

	.byte 4,4,7
	.asciz "uint"
LDIE_I8:

	.byte 4,8,5
	.asciz "long"
LDIE_U8:

	.byte 4,8,7
	.asciz "ulong"
LDIE_I:

	.byte 4,4,5
	.asciz "intptr"
LDIE_U:

	.byte 4,4,7
	.asciz "uintptr"
LDIE_R4:

	.byte 4,4,4
	.asciz "float"
LDIE_R8:

	.byte 4,8,4
	.asciz "double"
LDIE_BOOLEAN:

	.byte 4,1,2
	.asciz "boolean"
LDIE_CHAR:

	.byte 4,2,8
	.asciz "char"
LDIE_STRING:

	.byte 4,4,1
	.asciz "string"
LDIE_OBJECT:

	.byte 4,4,1
	.asciz "object"
LDIE_SZARRAY:

	.byte 4,4,1
	.asciz "object"
.section __DWARF, __debug_loc,regular,debug
Ldebug_loc_start:
.section __DWARF, __debug_frame,regular,debug
	.align 3

LDIFF_SYM2=Lcie0_end - Lcie0_start
	.long LDIFF_SYM2
Lcie0_start:

	.long -1
	.byte 3
	.asciz ""

	.byte 1,124,14
	.align 2
Lcie0_end:
.text
	.align 3
jit_code_start:

	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
.text
	.align 2
	.no_dead_strip System_Security_Cryptography_AesManaged__ctor
System_Security_Cryptography_AesManaged__ctor:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,3,223,77,226,0,0,141,229,0,0,157,229
bl _p_1

	.byte 0,0,157,229,32,31,160,227,28,16,128,229,3,223,141,226,0,1,189,232,128,128,189,232

Lme_0:
.text
	.align 2
	.no_dead_strip System_Security_Cryptography_AesManaged_GenerateIV
System_Security_Cryptography_AesManaged_GenerateIV:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,2,223,77,226,0,160,160,225,24,0,154,229,192,1,160,225
bl _p_2

	.byte 0,0,141,229,8,0,138,229,2,15,138,226
bl _p_3

	.byte 0,0,157,229,2,223,141,226,0,5,189,232,128,128,189,232

Lme_1:
.text
	.align 2
	.no_dead_strip System_Security_Cryptography_AesManaged_GenerateKey
System_Security_Cryptography_AesManaged_GenerateKey:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,2,223,77,226,0,160,160,225,32,0,154,229,192,1,160,225
bl _p_4

	.byte 0,0,141,229,12,0,138,229,3,15,138,226
bl _p_3

	.byte 0,0,157,229,2,223,141,226,0,5,189,232,128,128,189,232

Lme_2:
.text
	.align 2
	.no_dead_strip System_Security_Cryptography_AesManaged_CreateDecryptor_byte___byte__
System_Security_Cryptography_AesManaged_CreateDecryptor_byte___byte__:

	.byte 128,64,45,233,13,112,160,225,96,13,45,233,9,223,77,226,13,176,160,225,0,80,160,225,1,96,160,225,2,160,160,225
	.byte 0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 8
	.byte 0,0,159,231,0,0,144,229,8,0,139,229,5,0,160,225,0,16,149,229,15,224,160,225,88,240,145,229,64,3,64,226
	.byte 16,0,139,229,1,15,80,227,80,0,0,42,16,0,155,229,0,17,160,225,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 12
	.byte 0,0,159,231,1,0,128,224,0,0,144,229,0,240,160,225,64,3,160,227,0,31,160,227,0,47,160,227,6,48,160,225
	.byte 0,160,141,229
bl _p_5

	.byte 8,0,139,229,28,0,139,229,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 16
	.byte 0,0,159,231
bl _p_6

	.byte 28,16,155,229,24,0,139,229,5,32,160,225,0,63,160,227,0,160,141,229
bl _p_7

	.byte 24,0,155,229,74,0,0,234,64,3,160,227,0,31,160,227,128,35,160,227,6,48,160,225,0,160,141,229
bl _p_5

	.byte 8,0,139,229,28,0,139,229,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 16
	.byte 0,0,159,231
bl _p_6

	.byte 28,16,155,229,24,0,139,229,5,32,160,225,0,63,160,227,0,160,141,229
bl _p_7

	.byte 24,0,155,229,53,0,0,234,0,15,160,227,0,31,160,227,128,35,160,227,6,48,160,225,0,160,141,229
bl _p_5

	.byte 12,0,139,229,64,3,160,227,0,31,160,227,128,35,160,227,6,48,160,225,0,160,141,229
bl _p_5

	.byte 8,0,139,229,28,0,139,229,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 20
	.byte 0,0,159,231
bl _p_6

	.byte 28,16,155,229,24,0,139,229,12,32,155,229,5,48,160,225,0,207,160,227,0,192,141,229,4,160,141,229
bl _p_8

	.byte 24,0,155,229,23,0,0,234,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . -12
	.byte 0,0,159,231,64,19,160,227
bl _p_9

	.byte 24,0,139,229,5,0,160,225,0,16,149,229,15,224,160,225,88,240,145,229,28,0,139,229,100,15,160,227
bl _p_10

	.byte 0,16,160,225,24,0,155,229,28,32,155,229,8,32,129,229
bl _p_11

	.byte 0,16,160,225,147,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_12

	.byte 9,223,139,226,96,13,189,232,128,128,189,232

Lme_3:
.text
	.align 2
	.no_dead_strip System_Security_Cryptography_AesManaged_CreateEncryptor_byte___byte__
System_Security_Cryptography_AesManaged_CreateEncryptor_byte___byte__:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,8,223,77,226,13,176,160,225,0,80,160,225,1,96,160,225,2,160,160,225
	.byte 0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 8
	.byte 0,0,159,231,0,64,144,229,5,0,160,225,0,16,149,229,15,224,160,225,88,240,145,229,64,3,64,226,8,0,139,229
	.byte 1,15,80,227,79,0,0,42,8,0,155,229,0,17,160,225,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 24
	.byte 0,0,159,231,1,0,128,224,0,0,144,229,0,240,160,225,0,15,160,227,0,31,160,227,0,47,160,227,6,48,160,225
	.byte 0,160,141,229
bl _p_5

	.byte 0,64,160,225,20,0,139,229,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 16
	.byte 0,0,159,231
bl _p_6

	.byte 20,16,155,229,16,0,139,229,5,32,160,225,64,51,160,227,0,160,141,229
bl _p_7

	.byte 16,0,155,229,73,0,0,234,0,15,160,227,0,31,160,227,128,35,160,227,6,48,160,225,0,160,141,229
bl _p_5

	.byte 0,64,160,225,20,0,139,229,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 16
	.byte 0,0,159,231
bl _p_6

	.byte 20,16,155,229,16,0,139,229,5,32,160,225,64,51,160,227,0,160,141,229
bl _p_7

	.byte 16,0,155,229,52,0,0,234,0,15,160,227,0,31,160,227,128,35,160,227,6,48,160,225,0,160,141,229
bl _p_5

	.byte 0,64,160,225,20,0,139,229,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 8
	.byte 0,0,159,231,0,0,144,229,24,0,139,229,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . + 20
	.byte 0,0,159,231
bl _p_6

	.byte 20,16,155,229,24,32,155,229,16,0,139,229,5,48,160,225,64,195,160,227,0,192,141,229,4,160,141,229
bl _p_8

	.byte 16,0,155,229,23,0,0,234,0,0,159,229,0,0,0,234
	.long mono_aot_System_Core_got - . -12
	.byte 0,0,159,231,64,19,160,227
bl _p_9

	.byte 16,0,139,229,5,0,160,225,0,16,149,229,15,224,160,225,88,240,145,229,20,0,139,229,100,15,160,227
bl _p_10

	.byte 0,16,160,225,16,0,155,229,20,32,155,229,8,32,129,229
bl _p_11

	.byte 0,16,160,225,147,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_12

	.byte 8,223,139,226,112,13,189,232,128,128,189,232

Lme_4:
.text
	.align 3
jit_code_end:

	.byte 0,0,0,0
.text
	.align 3
method_addresses:
	.no_dead_strip method_addresses
bl System_Security_Cryptography_AesManaged__ctor
bl System_Security_Cryptography_AesManaged_GenerateIV
bl System_Security_Cryptography_AesManaged_GenerateKey
bl System_Security_Cryptography_AesManaged_CreateDecryptor_byte___byte__
bl System_Security_Cryptography_AesManaged_CreateEncryptor_byte___byte__
bl method_addresses
method_addresses_end:

.section __TEXT, __const
	.align 3
unbox_trampolines:
unbox_trampolines_end:

	.long 0
.text
	.align 3
unbox_trampoline_addresses:

	.long 0
.section __TEXT, __const
	.align 3
method_info_offsets:

	.byte 6,0,0,0,10,0,0,0,1,0,0,0,2,0,0,0,0,0,1,2,2,2,7,255,255,255,255,242
.section __TEXT, __const
	.align 3
extra_method_table:

	.byte 11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0
.section __TEXT, __const
	.align 3
extra_method_info_offsets:

	.byte 0,0,0,0
.section __TEXT, __const
	.align 3
class_name_table:

	.byte 11,0,1,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0
.section __TEXT, __const
	.align 3
got_info_offsets:

	.byte 10,0,0,0,10,0,0,0,1,0,0,0,2,0,0,0,0,0,22,2,1,1,1,1,7,9,4,4
.section __TEXT, __const
	.align 3
ex_info_offsets:

	.byte 6,0,0,0,10,0,0,0,1,0,0,0,2,0,0,0,0,0,128,208,19,25,25,128,185,255,255,255,254,50
.section __TEXT, __const
	.align 3
unwind_info:

	.byte 18,12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24,20,12,13,0,72,14,8,135,2,68,14,16,136
	.byte 4,138,3,142,1,68,14,24,29,12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142,1
	.byte 68,14,64,68,13,11,31,12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1
	.byte 68,14,64,68,13,11
.section __TEXT, __const
	.align 3
class_info_offsets:

	.byte 2,0,0,0,10,0,0,0,1,0,0,0,2,0,0,0,0,0,130,124,7

.text
	.align 4
plt:
mono_aot_System_Core_plt:
	.no_dead_strip plt_System_Security_Cryptography_Aes__ctor
plt_System_Security_Cryptography_Aes__ctor:
_p_1:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 40,61
	.no_dead_strip plt_Mono_Security_Cryptography_KeyBuilder_IV_int
plt_Mono_Security_Cryptography_KeyBuilder_IV_int:
_p_2:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 44,66
	.no_dead_strip plt_wrapper_write_barrier_object_wbarrier_noconc_intptr
plt_wrapper_write_barrier_object_wbarrier_noconc_intptr:
_p_3:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 48,71
	.no_dead_strip plt_Mono_Security_Cryptography_KeyBuilder_Key_int
plt_Mono_Security_Cryptography_KeyBuilder_Key_int:
_p_4:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 52,78
	.no_dead_strip plt_Crimson_CommonCrypto_Cryptor_Create_Crimson_CommonCrypto_CCOperation_Crimson_CommonCrypto_CCAlgorithm_Crimson_CommonCrypto_CCOptions_byte___byte__
plt_Crimson_CommonCrypto_Cryptor_Create_Crimson_CommonCrypto_CCOperation_Crimson_CommonCrypto_CCAlgorithm_Crimson_CommonCrypto_CCOptions_byte___byte__:
_p_5:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 56,83
	.no_dead_strip plt__jit_icall_mono_object_new_specific
plt__jit_icall_mono_object_new_specific:
_p_6:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 60,88
	.no_dead_strip plt_Crimson_CommonCrypto_FastCryptorTransform__ctor_intptr_System_Security_Cryptography_SymmetricAlgorithm_bool_byte__
plt_Crimson_CommonCrypto_FastCryptorTransform__ctor_intptr_System_Security_Cryptography_SymmetricAlgorithm_bool_byte__:
_p_7:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 64,115
	.no_dead_strip plt_Crimson_CommonCrypto_CryptorTransform__ctor_intptr_intptr_System_Security_Cryptography_SymmetricAlgorithm_bool_byte__
plt_Crimson_CommonCrypto_CryptorTransform__ctor_intptr_intptr_System_Security_Cryptography_SymmetricAlgorithm_bool_byte__:
_p_8:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 68,120
	.no_dead_strip plt__jit_icall_mono_helper_ldstr
plt__jit_icall_mono_helper_ldstr:
_p_9:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 72,125
	.no_dead_strip plt__jit_icall_mono_helper_newobj_mscorlib
plt__jit_icall_mono_helper_newobj_mscorlib:
_p_10:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 76,145
	.no_dead_strip plt_string_Format_string_object
plt_string_Format_string_object:
_p_11:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 80,175
	.no_dead_strip plt__jit_icall_mono_arch_throw_exception
plt__jit_icall_mono_arch_throw_exception:
_p_12:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Core_got - . + 84,180
plt_end:
.section __TEXT, __const
	.align 3
image_table:

	.byte 2,0,0,0,83,121,115,116,101,109,46,67,111,114,101,0,55,54,68,48,65,55,50,70,45,48,50,56,70,45,52,70
	.byte 56,48,45,56,66,55,51,45,52,51,48,66,67,50,50,51,70,51,68,54,0,0,55,99,101,99,56,53,100,55,98,101
	.byte 97,55,55,57,56,101,0,0,1,0,0,0,2,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,109,115,99,111
	.byte 114,108,105,98,0,54,67,66,49,50,52,69,52,45,55,67,57,53,45,52,52,48,50,45,56,48,48,68,45,53,56,70
	.byte 68,65,57,55,67,67,49,66,54,0,0,55,99,101,99,56,53,100,55,98,101,97,55,55,57,56,101,0,0,0,0,0
	.byte 1,0,0,0,2,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0
.section __DATA, __bss
	.align 3
.lcomm mono_aot_System_Core_got, 92
.section __TEXT, __const
	.align 2
runtime_version:
	.asciz ""
.section __TEXT, __const
	.align 2
assembly_guid:
	.asciz "76D0A72F-028F-4F80-8B73-430BC223F3D6"
.section __TEXT, __const
	.align 2
assembly_name:
	.asciz "System.Core"
.data
	.align 3
_mono_aot_file_info:

	.long 119,0
	.align 2
	.long mono_aot_System_Core_got
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long jit_code_start
	.align 2
	.long jit_code_end
	.align 2
	.long method_addresses
	.align 2
	.long blob
	.align 2
	.long class_name_table
	.align 2
	.long class_info_offsets
	.align 2
	.long method_info_offsets
	.align 2
	.long ex_info_offsets
	.align 2
	.long extra_method_info_offsets
	.align 2
	.long extra_method_table
	.align 2
	.long got_info_offsets
	.align 2
	.long 0
	.align 2
	.long mem_end
	.align 2
	.long image_table
	.align 2
	.long assembly_guid
	.align 2
	.long runtime_version
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long globals
	.align 2
	.long assembly_name
	.align 2
	.long plt
	.align 2
	.long plt_end
	.align 2
	.long unwind_info
	.align 2
	.long unbox_trampolines
	.align 2
	.long unbox_trampolines_end
	.align 2
	.long unbox_trampoline_addresses

	.long 10,92,13,6,2,387000831,0,738
	.long 128,4,4,15,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0
	.globl _mono_aot_module_System_Core_info
	.align 2
_mono_aot_module_System_Core_info:
	.align 2
	.long _mono_aot_file_info
.section __TEXT, __const
	.align 3
blob:

	.byte 0,0,0,0,0,0,0,0,5,5,6,7,7,8,0,6,5,9,7,7,5,8,12,0,39,42,52,47,16,2,131,51
	.byte 1,140,80,8,4,124,128,208,129,156,129,36,14,2,10,1,14,2,8,1,8,4,120,128,204,129,148,129,32,3,193,0
	.byte 9,7,3,193,0,16,24,3,255,252,0,0,0,24,3,193,0,16,23,3,193,0,0,5,7,24,109,111,110,111,95,111
	.byte 98,106,101,99,116,95,110,101,119,95,115,112,101,99,105,102,105,99,0,3,193,0,0,22,3,193,0,0,13,7,17,109
	.byte 111,110,111,95,104,101,108,112,101,114,95,108,100,115,116,114,0,7,27,109,111,110,111,95,104,101,108,112,101,114,95,110
	.byte 101,119,111,98,106,95,109,115,99,111,114,108,105,98,0,3,193,0,10,20,7,25,109,111,110,111,95,97,114,99,104,95
	.byte 116,104,114,111,119,95,101,120,99,101,112,116,105,111,110,0,2,0,16,40,24,52,208,0,0,13,0,0,3,1,24,11
	.byte 12,6,4,2,19,22,52,20,64,10,0,8,2,20,6,4,1,4,5,8,0,4,0,4,0,8,6,0,2,19,22,52
	.byte 20,64,10,0,8,2,20,6,4,1,4,5,8,0,4,0,4,0,8,6,0,2,40,128,181,129,252,32,130,8,6,10
	.byte 5,208,0,0,11,8,255,48,0,0,0,208,0,0,11,12,0,78,0,32,0,16,7,8,0,4,0,4,8,8,1,8
	.byte 0,4,0,8,0,4,0,16,0,4,0,4,31,4,0,4,0,4,0,4,0,4,0,4,10,12,0,16,0,8,0,4
	.byte 0,4,0,4,0,4,5,8,6,4,0,4,0,4,0,4,0,4,0,4,10,12,0,16,0,8,0,4,0,4,0,4
	.byte 0,4,5,8,6,4,0,4,0,4,0,4,0,4,0,4,11,8,0,4,0,4,0,4,0,4,0,4,11,12,0,16
	.byte 0,8,0,8,0,8,0,4,0,4,5,8,1,4,0,16,0,4,6,8,0,4,0,4,5,12,0,4,0,4,0,12
	.byte 5,4,0,4,5,4,0,8,5,4,0,4,1,0,2,70,128,170,129,244,32,130,0,6,10,5,4,255,48,0,0,0
	.byte 0,77,0,32,0,16,7,4,0,4,0,4,8,8,1,8,0,4,0,8,0,4,0,16,0,4,0,4,31,4,0,4
	.byte 0,4,0,4,0,4,0,4,0,4,10,8,0,16,0,8,0,4,0,4,0,4,0,4,5,8,6,4,0,4,0,4
	.byte 0,4,0,4,0,4,0,4,10,8,0,16,0,8,0,4,0,4,0,4,0,4,5,8,6,4,0,4,0,4,0,4
	.byte 0,4,0,4,0,4,7,8,0,16,8,8,0,16,0,12,0,4,0,8,0,4,0,4,5,8,1,4,0,16,0,4
	.byte 6,8,0,4,0,4,5,12,0,4,0,4,0,12,5,4,0,4,5,4,0,8,5,4,0,4,1,0,0,128,144,8
	.byte 0,0,1,25,128,160,44,0,0,4,193,0,22,0,193,0,21,253,193,0,21,252,193,0,21,250,193,0,9,135,2,3
	.byte 4,193,0,9,154,5,193,0,9,152,193,0,9,150,193,0,9,149,193,0,9,148,193,0,9,147,193,0,9,146,193,0
	.byte 9,145,193,0,9,144,193,0,9,143,193,0,9,142,193,0,9,141,193,0,9,140,193,0,9,139,193,0,9,138,193,0
	.byte 9,137,115,103,101,110,0
.section __TEXT, __const
	.align 3
Lglobals_hash:

	.short 11, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.data
	.align 3
globals:
	.align 2
	.long Lglobals_hash

	.long 0,0
.section __DWARF, __debug_info,regular,debug
LTDIE_3:

	.byte 17
	.asciz "System_Object"

	.byte 8,7
	.asciz "System_Object"

LDIFF_SYM3=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM3
LTDIE_3_POINTER:

	.byte 13
LDIFF_SYM4=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM4
LTDIE_3_REFERENCE:

	.byte 14
LDIFF_SYM5=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM5
LTDIE_5:

	.byte 5
	.asciz "System_ValueType"

	.byte 8,16
LDIFF_SYM6=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM6
	.byte 2,35,0,0,7
	.asciz "System_ValueType"

LDIFF_SYM7=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM7
LTDIE_5_POINTER:

	.byte 13
LDIFF_SYM8=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM8
LTDIE_5_REFERENCE:

	.byte 14
LDIFF_SYM9=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM9
LTDIE_4:

	.byte 5
	.asciz "System_Int32"

	.byte 12,16
LDIFF_SYM10=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM10
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM11=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM11
	.byte 2,35,8,0,7
	.asciz "System_Int32"

LDIFF_SYM12=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM12
LTDIE_4_POINTER:

	.byte 13
LDIFF_SYM13=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM13
LTDIE_4_REFERENCE:

	.byte 14
LDIFF_SYM14=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM14
LTDIE_6:

	.byte 8
	.asciz "System_Security_Cryptography_CipherMode"

	.byte 4
LDIFF_SYM15=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM15
	.byte 9
	.asciz "CBC"

	.byte 1,9
	.asciz "ECB"

	.byte 2,9
	.asciz "OFB"

	.byte 3,9
	.asciz "CFB"

	.byte 4,9
	.asciz "CTS"

	.byte 5,0,7
	.asciz "System_Security_Cryptography_CipherMode"

LDIFF_SYM16=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM16
LTDIE_6_POINTER:

	.byte 13
LDIFF_SYM17=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM17
LTDIE_6_REFERENCE:

	.byte 14
LDIFF_SYM18=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM18
LTDIE_7:

	.byte 8
	.asciz "System_Security_Cryptography_PaddingMode"

	.byte 4
LDIFF_SYM19=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM19
	.byte 9
	.asciz "None"

	.byte 1,9
	.asciz "PKCS7"

	.byte 2,9
	.asciz "Zeros"

	.byte 3,9
	.asciz "ANSIX923"

	.byte 4,9
	.asciz "ISO10126"

	.byte 5,0,7
	.asciz "System_Security_Cryptography_PaddingMode"

LDIFF_SYM20=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM20
LTDIE_7_POINTER:

	.byte 13
LDIFF_SYM21=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM21
LTDIE_7_REFERENCE:

	.byte 14
LDIFF_SYM22=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM22
LTDIE_2:

	.byte 5
	.asciz "System_Security_Cryptography_SymmetricAlgorithm"

	.byte 44,16
LDIFF_SYM23=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM23
	.byte 2,35,0,6
	.asciz "BlockSizeValue"

LDIFF_SYM24=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM24
	.byte 2,35,24,6
	.asciz "FeedbackSizeValue"

LDIFF_SYM25=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM25
	.byte 2,35,28,6
	.asciz "IVValue"

LDIFF_SYM26=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM26
	.byte 2,35,8,6
	.asciz "KeyValue"

LDIFF_SYM27=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM27
	.byte 2,35,12,6
	.asciz "LegalBlockSizesValue"

LDIFF_SYM28=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM28
	.byte 2,35,16,6
	.asciz "LegalKeySizesValue"

LDIFF_SYM29=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM29
	.byte 2,35,20,6
	.asciz "KeySizeValue"

LDIFF_SYM30=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM30
	.byte 2,35,32,6
	.asciz "ModeValue"

LDIFF_SYM31=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM31
	.byte 2,35,36,6
	.asciz "PaddingValue"

LDIFF_SYM32=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM32
	.byte 2,35,40,0,7
	.asciz "System_Security_Cryptography_SymmetricAlgorithm"

LDIFF_SYM33=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM33
LTDIE_2_POINTER:

	.byte 13
LDIFF_SYM34=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM34
LTDIE_2_REFERENCE:

	.byte 14
LDIFF_SYM35=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM35
LTDIE_1:

	.byte 5
	.asciz "System_Security_Cryptography_Aes"

	.byte 44,16
LDIFF_SYM36=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM36
	.byte 2,35,0,0,7
	.asciz "System_Security_Cryptography_Aes"

LDIFF_SYM37=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM37
LTDIE_1_POINTER:

	.byte 13
LDIFF_SYM38=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM38
LTDIE_1_REFERENCE:

	.byte 14
LDIFF_SYM39=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM39
LTDIE_0:

	.byte 5
	.asciz "System_Security_Cryptography_AesManaged"

	.byte 44,16
LDIFF_SYM40=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM40
	.byte 2,35,0,0,7
	.asciz "System_Security_Cryptography_AesManaged"

LDIFF_SYM41=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM41
LTDIE_0_POINTER:

	.byte 13
LDIFF_SYM42=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM42
LTDIE_0_REFERENCE:

	.byte 14
LDIFF_SYM43=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM43
	.byte 2
	.asciz "System.Security.Cryptography.AesManaged:.ctor"
	.asciz "System_Security_Cryptography_AesManaged__ctor"

	.byte 1,18
	.long System_Security_Cryptography_AesManaged__ctor
	.long Lme_0

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM44=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM44
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM45=Lfde0_end - Lfde0_start
	.long LDIFF_SYM45
Lfde0_start:

	.long 0
	.align 2
	.long System_Security_Cryptography_AesManaged__ctor

LDIFF_SYM46=Lme_0 - System_Security_Cryptography_AesManaged__ctor
	.long LDIFF_SYM46
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde0_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Security.Cryptography.AesManaged:GenerateIV"
	.asciz "System_Security_Cryptography_AesManaged_GenerateIV"

	.byte 1,26
	.long System_Security_Cryptography_AesManaged_GenerateIV
	.long Lme_1

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM47=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM47
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM48=Lfde1_end - Lfde1_start
	.long LDIFF_SYM48
Lfde1_start:

	.long 0
	.align 2
	.long System_Security_Cryptography_AesManaged_GenerateIV

LDIFF_SYM49=Lme_1 - System_Security_Cryptography_AesManaged_GenerateIV
	.long LDIFF_SYM49
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde1_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Security.Cryptography.AesManaged:GenerateKey"
	.asciz "System_Security_Cryptography_AesManaged_GenerateKey"

	.byte 1,31
	.long System_Security_Cryptography_AesManaged_GenerateKey
	.long Lme_2

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM50=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM50
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM51=Lfde2_end - Lfde2_start
	.long LDIFF_SYM51
Lfde2_start:

	.long 0
	.align 2
	.long System_Security_Cryptography_AesManaged_GenerateKey

LDIFF_SYM52=Lme_2 - System_Security_Cryptography_AesManaged_GenerateKey
	.long LDIFF_SYM52
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde2_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Security.Cryptography.AesManaged:CreateDecryptor"
	.asciz "System_Security_Cryptography_AesManaged_CreateDecryptor_byte___byte__"

	.byte 1,36
	.long System_Security_Cryptography_AesManaged_CreateDecryptor_byte___byte__
	.long Lme_3

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM53=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM53
	.byte 1,85,3
	.asciz "rgbKey"

LDIFF_SYM54=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM54
	.byte 1,86,3
	.asciz "rgbIV"

LDIFF_SYM55=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM55
	.byte 1,90,11
	.asciz "decryptor"

LDIFF_SYM56=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM56
	.byte 2,123,8,11
	.asciz ""

LDIFF_SYM57=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM57
	.byte 0,11
	.asciz "encryptor"

LDIFF_SYM58=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM58
	.byte 2,123,12,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM59=Lfde3_end - Lfde3_start
	.long LDIFF_SYM59
Lfde3_start:

	.long 0
	.align 2
	.long System_Security_Cryptography_AesManaged_CreateDecryptor_byte___byte__

LDIFF_SYM60=Lme_3 - System_Security_Cryptography_AesManaged_CreateDecryptor_byte___byte__
	.long LDIFF_SYM60
	.byte 12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142,1,68,14,64,68,13,11
	.align 2
Lfde3_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Security.Cryptography.AesManaged:CreateEncryptor"
	.asciz "System_Security_Cryptography_AesManaged_CreateEncryptor_byte___byte__"

	.byte 1,59
	.long System_Security_Cryptography_AesManaged_CreateEncryptor_byte___byte__
	.long Lme_4

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM61=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM61
	.byte 1,85,3
	.asciz "rgbKey"

LDIFF_SYM62=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM62
	.byte 1,86,3
	.asciz "rgbIV"

LDIFF_SYM63=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM63
	.byte 1,90,11
	.asciz "encryptor"

LDIFF_SYM64=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM64
	.byte 1,84,11
	.asciz ""

LDIFF_SYM65=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM65
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM66=Lfde4_end - Lfde4_start
	.long LDIFF_SYM66
Lfde4_start:

	.long 0
	.align 2
	.long System_Security_Cryptography_AesManaged_CreateEncryptor_byte___byte__

LDIFF_SYM67=Lme_4 - System_Security_Cryptography_AesManaged_CreateEncryptor_byte___byte__
	.long LDIFF_SYM67
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,64,68,13,11
	.align 2
Lfde4_end:

.section __DWARF, __debug_info,regular,debug

	.byte 0
Ldebug_info_end:
.section __DWARF, __debug_line,regular,debug
Ldebug_line_section_start:
Ldebug_line_start:

	.long Ldebug_line_end - . -4
	.short 2
	.long Ldebug_line_header_end - . -4
	.byte 1,1,251,14,13,0,1,1,1,1,0,0,0,1,0,0,1
.section __DWARF, __debug_line,regular,debug
	.asciz "/Users/builder/data/lanes/2356/3c0ec355/source/maccore/src/CommonCrypto"

	.byte 0
	.asciz "AesManaged.g.cs"

	.byte 1,0,0
	.asciz "<unknown>"

	.byte 0,0,0,0
Ldebug_line_header_end:
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long System_Security_Cryptography_AesManaged__ctor

	.byte 4,1,1,10,3,17,2,24,1,188,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long System_Security_Cryptography_AesManaged_GenerateIV

	.byte 4,1,1,10,3,25,2,20,1,2,44,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long System_Security_Cryptography_AesManaged_GenerateKey

	.byte 4,1,1,10,3,30,2,20,1,2,44,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long System_Security_Cryptography_AesManaged_CreateDecryptor_byte___byte__

	.byte 4,1,1,10,3,35,2,32,1,8,117,3,2,2,196,0,1,8,229,3,2,2,52,1,8,229,3,3,2,52,1,8
	.byte 173,8,229,3,5,2,60,1,2,236,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long System_Security_Cryptography_AesManaged_CreateEncryptor_byte___byte__

	.byte 4,1,1,10,3,58,2,32,1,8,61,3,2,2,196,0,1,8,229,3,2,2,52,1,8,229,3,3,2,52,1,8
	.byte 229,3,5,2,212,0,1,2,236,0,1,0,1,1,0,1,1
Ldebug_line_end:
.text
	.align 3
mem_end:
