# standard #("" name)
# {
#     structural <Array>element :"" data;
#     structural combine classes name data;
#     \keytoken : static (readonly)\ \keytoken : partial (readonly)\ keytoken : class name 
#     {<>
#         //implicit 
#         predicate(\is\ static) 
#         {
#             extern input :
#             static (explicit) name()
#             {

#             }
#         }
#         data += name;
#         //end
#     }<>
#     <create statement "class"> <message : Class> name =: Name
#     predicate(\is\ static)
#     {
#         internal input :
#         name variable = value; #("" variable) 
#         ref r = matching reference not 0;
#         contains value in r at value;
#         create value null = ref 0;
#     }
# }
