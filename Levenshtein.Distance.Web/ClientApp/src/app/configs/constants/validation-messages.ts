
export const messages = {
    firstString: [
      { type: 'required', message: 'First string is required' },
      {
        type: 'pattern', message: `Value can be alphabates
        and can not start with space, number and underscore !`
      }
    ],
    secondString: [
        { type: 'required', message: 'Second string is required' },
        {
          type: 'pattern', message: `Value can be alphabates
          and can not start with space, number and underscore !`
        }
      ],
  }
  