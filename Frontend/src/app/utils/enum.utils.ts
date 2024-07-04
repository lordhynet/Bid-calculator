export function enumToArray(enumObj: any): { key: number, value: string }[] {
    return Object.keys(enumObj)
      .filter(key => !isNaN(Number(enumObj[key])))
      .map(key => ({ key: enumObj[key], value: key }));
  }
  