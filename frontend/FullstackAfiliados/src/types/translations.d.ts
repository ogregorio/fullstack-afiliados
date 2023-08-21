import dict from '../langs/translations/pt.json';

declare function t<S extends string>(p: DeepKeys<typeof dict, S>): GetDictValue<S, typeof dict>

type GetDictValue<T extends string, O> =
    T extends `${infer A}.${infer B}` ? A extends keyof O ? GetDictValue<B, O[A]> : never
    : T extends keyof O ? O[T] : never

// T is the dictionary, S ist the next string part of the object property path
// If S does not match dict shape, return its next expected properties
type DeepKeys<T, S extends string> =
    T extends object
    ? S extends `${infer I1}.${infer I2}`
        ? I1 extends keyof T
            // Fix issue allowed last dot
            ? T[I1] extends object
                ? `${I1}.${DeepKeys<T[I1], I2>}`
                : keyof T & string
            : keyof T & string
        : S extends keyof T
            ? `${S}`
            : keyof T & string
    : ''

declare global {
  const t: <S extends string>(
    p: DeepKeys<typeof dict, S>, obj?: any) => GetDictValue<P, typeof dict>;
}
